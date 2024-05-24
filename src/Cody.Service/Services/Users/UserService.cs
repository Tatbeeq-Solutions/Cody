using AutoMapper;
using Cody.DataAccess.UnitOfWorks;
using Cody.Domain.Entities;
using Cody.Domain.Enums;
using Cody.Service.Configurations;
using Cody.Service.DTOs.Users;
using Cody.Service.Exceptions;
using Cody.Service.Extensions;
using Cody.Service.Helpers;
using Cody.Service.Validators.Accounts;
using Cody.Service.Validators.Users;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Cody.Service.Services.Users;

public class UserService(IMapper mapper,
                         IUnitOfWork unitOfWork,
                         UserCreateDtoValidator createDtoValidator,
                         UserUpdateDtoValidator updateDtoValidator,
                         ChangePasswordDtoValidator changePasswordDtoValidator) : IUserService
{
    public async Task<UserResultDto> CreateAsync(UserCreateDto createDto)
    {
        await createDtoValidator.EnsureValidatedAsync(createDto);
        var existUser = await unitOfWork.Users.SelectAsync(u => u.Phone == createDto.Phone);
        if (existUser is not null)
            throw new AlreadyExistException($"User already exists with this phone: {createDto.Phone}");

        var mappedUser = mapper.Map<User>(createDto);
        mappedUser.Role = Role.Admin;
        mappedUser.CreatedBy = HttpContextHelper.UserId;
        mappedUser.PasswordHash = PasswordHasher.Hash(createDto.Password);

        var createdUser = await unitOfWork.Users.InsertAsync(mappedUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserResultDto>(createdUser);
    }

    public async Task<UserResultDto> ModifyAsync(long id, UserUpdateDto updateDto)
    {
        await updateDtoValidator.EnsureValidatedAsync(updateDto);
        var existUser = await unitOfWork.Users.SelectAsync(u => id == u.Id)
            ?? throw new NotFoundException($"User is not found with this id: {id}");

        var alreadyExistUser = await unitOfWork.Users.SelectAsync(u => u.Id != id && u.Phone == updateDto.Phone);
        if (alreadyExistUser is not null)
            throw new AlreadyExistException($"User already exists with this phone: {updateDto.Phone}");

        mapper.Map(updateDto, existUser);
        existUser.UpdatedBy = HttpContextHelper.UserId;
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserResultDto>(existUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => id == u.Id)
           ?? throw new NotFoundException($"User is not found with this id: {id}");

        existUser.DeletedBy = HttpContextHelper.UserId;
        await unitOfWork.Users.DeleteAsync(existUser);

        return await unitOfWork.SaveAsync();
    }

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => id == u.Id)
           ?? throw new NotFoundException($"User is not found with this id: {id}");

        return mapper.Map<UserResultDto>(existUser);
    }

    public async Task<UserResultDto> RetrieveByPhoneAsync(string phone)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => phone == u.Phone)
           ?? throw new NotFoundException($"User is not found with this phone: {phone}");

        return mapper.Map<UserResultDto>(existUser);
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter)
    {
        var users = unitOfWork.Users.SelectAsQueryable().OrderBy(filter);
        var paginatedUsers = await users.ToPaginate(@params).ToListAsync(); 
        return mapper.Map<IEnumerable<UserResultDto>>(paginatedUsers);
    }

    public async Task<UserResultDto> ChangePasswordAsync(long id, ChangePasswordDto changePasswordDto)
    {
        await changePasswordDtoValidator.EnsureValidatedAsync(changePasswordDto);
        var existUser = await unitOfWork.Users.SelectAsync(u => id == u.Id)
           ?? throw new NotFoundException($"User is not found with this id: {id}");

        if (!PasswordHasher.Verify(changePasswordDto.OldPassword, existUser.PasswordHash))
            throw new ArgumentIsNotValidException($"Passord is not match with yours");

        existUser.PasswordHash = PasswordHasher.Hash(changePasswordDto.NewPassword);
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserResultDto>(existUser);
    }

    public string GeneratePassword()
    {
        var random = new Random();
        var length = random.Next(8, 16);

        const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";

        var password = new StringBuilder();

        // Ensure at least one character from each required set
        password.Append(upperCase[random.Next(upperCase.Length)]);
        password.Append(lowerCase[random.Next(lowerCase.Length)]);
        password.Append(digits[random.Next(digits.Length)]);

        // Fill the rest of the password to meet the desired length
        string allChars = upperCase + lowerCase + digits;
        for (int i = password.Length; i < length; i++)
            password.Append(allChars[random.Next(allChars.Length)]);

        // Shuffle the password to ensure randomness
        var shuffledPassword = new string(password.ToString().ToCharArray().OrderBy(x => random.Next()).ToArray());

        return shuffledPassword;
    }
}
