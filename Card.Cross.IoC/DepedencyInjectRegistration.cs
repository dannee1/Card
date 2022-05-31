using Card.Database.Context;
using Card.Database.Repositories;
using Card.Database.UnitOfWork;
using Card.Domain.Interfaces;
using Card.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Card.Cross.IoC
{
    public static class DepedencyInjectRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Services
            services.AddScoped<ICardService, CardService>();
            
            //Repository
            services.AddScoped<ICardRepository, CardRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Context
            //services.AddScoped<CardContext>();
            //services.AddScoped<DbContextOptions<CardContext>>();
            services.AddDbContext<CardContext>(opt => opt.UseInMemoryDatabase("eCard",null));
        }
    }
}
