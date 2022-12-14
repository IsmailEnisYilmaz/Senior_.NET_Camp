using Application.Features.Auths.Rules;
using Application.Features.Brands.Rules;
using Application.Services.AuthService;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.addtransient(typeof(ıpipelinebehavior<,>), typeof(authorizationbehavior<,>));
            //services.addtransient(typeof(ıpipelinebehavior<,>), typeof(cachingbehavior<,>));
            //services.addtransient(typeof(ıpipelinebehavior<,>), typeof(cacheremovingbehavior<,>));
            //services.addtransient(typeof(ıpipelinebehavior<,>), typeof(loggingbehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService,AuthManager>();

            return services;

        }
    }
}
