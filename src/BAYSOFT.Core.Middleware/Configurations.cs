using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelWrapper.Middleware;
using System;
using System.Reflection;

namespace BAYSOFT.Core.Middleware
{
    public static class Configurations
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration, Assembly presentationAssembly)
        {
            services.AddDbContexts(configuration, presentationAssembly);
            services.AddEntityValidations();
            services.AddSpecifications();
            services.AddDomainValidations();
            services.AddDomainServices();

            var assembly = AppDomain.CurrentDomain.Load("BAYSOFT.Core.Application");

            services.AddMediatR(assembly);

            services.AddModelWrapper()
                .AddDefaultReturnedCollectionSize(5)
                .AddMinimumReturnedCollectionSize(1)
                .AddMaximumReturnedCollectionSize(100)
                .AddQueryTermsMinimumSize(3)
                .AddSuppressedTerms(new string[] { "the" });

            // YOUR CODE GOES HERE
            return services;
        }

        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            //app.UseAuthentication();
            //app.UseAuthorization();
            // YOUR CODE GOES HERE
            return app;
        }
    }
}
