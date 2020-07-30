using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Grades;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Orders;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Prices;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Samples;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Sectors;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Stocks;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Stops;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.SubSectors;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Wallets;
using BAYSOFT.Core.Domain.Validations.EntityValidations.StockWallet;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using BAYSOFT.Core.Domain.Validations.Specifications.StockWallet.Samples;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Middleware
{
    public static class DomainValidationsConfigurations
    {
        public static IServiceCollection AddEntityValidations(this IServiceCollection services)
        {
            services.AddTransient<SampleValidator>();
            services.AddTransient<GradeValidator>();
            services.AddTransient<OrderValidator>();
            services.AddTransient<PriceValidator>();
            services.AddTransient<SectorValidator>();
            services.AddTransient<StockValidator>();
            services.AddTransient<StopValidator>();
            services.AddTransient<SubSectorValidator>();
            services.AddTransient<WalletValidator>();

            return services;
        }

        public static IServiceCollection AddDomainValidations(this IServiceCollection services)
        {
            services.AddTransient<PutSampleSpecificationsValidator>();
            services.AddTransient<PostSampleSpecificationsValidator>();
            services.AddTransient<PatchSampleSpecificationsValidator>();
            services.AddTransient<DeleteSampleSpecificationsValidator>();

            services.AddTransient<PutGradeSpecificationsValidator>();
            services.AddTransient<PostGradeSpecificationsValidator>();
            services.AddTransient<PatchGradeSpecificationsValidator>();
            services.AddTransient<DeleteGradeSpecificationsValidator>();

            services.AddTransient<PutOrderSpecificationsValidator>();
            services.AddTransient<PostOrderSpecificationsValidator>();
            services.AddTransient<PatchOrderSpecificationsValidator>();
            services.AddTransient<DeleteOrderSpecificationsValidator>();

            services.AddTransient<PutPriceSpecificationsValidator>();
            services.AddTransient<PostPriceSpecificationsValidator>();
            services.AddTransient<PatchPriceSpecificationsValidator>();
            services.AddTransient<DeletePriceSpecificationsValidator>();

            services.AddTransient<PutSectorSpecificationsValidator>();
            services.AddTransient<PostSectorSpecificationsValidator>();
            services.AddTransient<PatchSectorSpecificationsValidator>();
            services.AddTransient<DeleteSectorSpecificationsValidator>();

            services.AddTransient<PutStockSpecificationsValidator>();
            services.AddTransient<PostStockSpecificationsValidator>();
            services.AddTransient<PatchStockSpecificationsValidator>();
            services.AddTransient<DeleteStockSpecificationsValidator>();

            services.AddTransient<PutStopSpecificationsValidator>();
            services.AddTransient<PostStopSpecificationsValidator>();
            services.AddTransient<PatchStopSpecificationsValidator>();
            services.AddTransient<DeleteStopSpecificationsValidator>();

            services.AddTransient<PutSubSectorSpecificationsValidator>();
            services.AddTransient<PostSubSectorSpecificationsValidator>();
            services.AddTransient<PatchSubSectorSpecificationsValidator>();
            services.AddTransient<DeleteSubSectorSpecificationsValidator>();

            services.AddTransient<PutWalletSpecificationsValidator>();
            services.AddTransient<PostWalletSpecificationsValidator>();
            services.AddTransient<PatchWalletSpecificationsValidator>();
            services.AddTransient<DeleteWalletSpecificationsValidator>();

            return services;
        }

        public static IServiceCollection AddSpecifications(this IServiceCollection services)
        {
            services.AddTransient<SampleDescriptionAlreadyExistsSpecification>();

            return services;
        }
    }
}
