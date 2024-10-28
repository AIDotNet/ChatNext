﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChatNext.Application.Contract.Users.Dto;
using Gnarly.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ChatNext.Application.Infrastructure;

public class JwtHelper(IConfiguration configuration) : IScopeDependency
{
    public string CreateToken(UserDto user)
    {
        // 1. 定义需要使用到的Claims
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            // new Claim(ClaimTypes.Role, user.)
        };

        // 2. 从 appsettings.json 中读取SecretKey
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]));

        // 3. 选择加密算法
        var algorithm = SecurityAlgorithms.HmacSha256;

        // 4. 生成Credentials
        var signingCredentials = new SigningCredentials(secretKey, algorithm);

        // 5. 根据以上，生成token
        var jwtSecurityToken = new JwtSecurityToken(
            "ChatNext", //Issuer
            "ChatNext", //Audience
            claims, //Claims,
            DateTime.Now, //notBefore
            DateTime.Now.AddHours(configuration.GetValue<int>("Jwt:EffectiveHours")), //expires
            signingCredentials //Credentials
        );

        // 6. 将token变为string
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token;
    }

    public UserDto? GetUserFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

        if (jsonToken == null)
            return null;

        var userName = jsonToken?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var id = jsonToken?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
        // var role = jsonToken?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

        return new UserDto()
        {
            Username = userName,
            Id = Guid.Parse(id),
        };
    }

    public IEnumerable<Claim> GetClaimsFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

        return jsonToken?.Claims;
    }
}