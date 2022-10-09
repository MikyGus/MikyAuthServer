﻿using Dapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MikyAuth.Library.Converters;
using MikyAuth.Library.Entities;
using MikyAuth.Library.PersistentStorage;
using MikyAuth.Library.Stores;
using System.Text;

namespace MikyAuth.Library.Gateway;
public static class AuthServerExtension
{
    public static IServiceCollection AddMikyAuthServer(
        this IServiceCollection services,
        Action<AuthServerOption>? options = null)
    {
        // Configurations
        _ = services.Configure(options);

        SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());
        SqlMapper.RemoveTypeMap(typeof(Guid));
        SqlMapper.RemoveTypeMap(typeof(Guid?));

        //AuthServer
        services = services.AddScoped<IAuthServerGate, AuthServerGate>();
        services = services.AddSingleton<IDbAccess, DbAccessMySql>();

        //Identity
        services = services.AddScoped<ILookupNormalizer, StringNormalizer>();
        services = services.AddSingleton<IUserStore<AuthUser>, UserStore>();

        _ = services.AddIdentityCore<AuthUser>();

        string SecretServerKey = Guid.NewGuid().ToString(); //TODO: Remove me, replace with below
        //var SecretServerKey = builder.Configuration
        //    .GetSection("ServerAuthentication").GetValue<string>("SecretKey");
        var key = Encoding.ASCII.GetBytes(SecretServerKey);
        _ = services.AddAuthentication(x =>
        {
            //x.DefaultScheme = IdentityConstants.ApplicationScheme;
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userMachine = context.HttpContext.RequestServices
                            .GetRequiredService<UserManager<AuthUser>>();
                        var user = userMachine.GetUserAsync(context.HttpContext.User);
                        if (user is null)
                        {
                            context.Fail("UnAuthorized");
                        }

                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });




        return services;
    }
}
