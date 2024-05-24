﻿namespace Cody.Service.Options;

public class JwtOptions
{
    public required string Key { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required int LifeTime { get; set; }
}
