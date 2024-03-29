﻿using Accounts.Common.User;
using Accounts.Core.Models;
using Accounts.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Implementation
{
    public class JwtService : IJwtService
    {
        public readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public JwtService(IConfiguration config, UserManager<User> userManager)
        {
            _configuration = config;
            _userManager = userManager;
        }
        //public UserModel Authenticate(UserLogin userLogin)
        //{
        //    var currentUser = UserConstant.Users.FirstOrDefault(x => x.Username.ToLower() ==
        //        userLogin.Username.ToLower() && x.Password == userLogin.Password);
        //    if (currentUser != null)
        //    {
        //        return currentUser;
        //    }
        //    return null;
        //}

        //public string GenerateToken(UserModel user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,user.Username),
        //        new Claim(ClaimTypes.Role,user.Role)
        //    };
        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: credentials);


        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                 issuer: _configuration["Jwt:Issuer"],
                 audience:_configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
