using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Grades;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Orders;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Prices;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Samples;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Sectors;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stocks;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stops;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.SubSectors;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Wallets;
using BAYSOFT.Core.Domain.Services.StockWallet.Grades;
using BAYSOFT.Core.Domain.Services.StockWallet.Orders;
using BAYSOFT.Core.Domain.Services.StockWallet.Prices;
using BAYSOFT.Core.Domain.Services.StockWallet.Samples;
using BAYSOFT.Core.Domain.Services.StockWallet.Sectors;
using BAYSOFT.Core.Domain.Services.StockWallet.Stocks;
using BAYSOFT.Core.Domain.Services.StockWallet.Stops;
using BAYSOFT.Core.Domain.Services.StockWallet.SubSectors;
using BAYSOFT.Core.Domain.Services.StockWallet.Wallets;
using Microsoft.Extensions.DependencyInjection;

namespace BAYSOFT.Core.Middleware
{
    public static class DomainServicesConfigurations
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPutSampleService, PutSampleService>();
            services.AddTransient<IPostSampleService, PostSampleService>();
            services.AddTransient<IPatchSampleService, PatchSampleService>();
            services.AddTransient<IDeleteSampleService, DeleteSampleService>();

            services.AddTransient<IPutGradeService, PutGradeService>();
            services.AddTransient<IPostGradeService, PostGradeService>();
            services.AddTransient<IPatchGradeService, PatchGradeService>();
            services.AddTransient<IDeleteGradeService, DeleteGradeService>();

            services.AddTransient<IPutOrderService, PutOrderService>();
            services.AddTransient<IPostOrderService, PostOrderService>();
            services.AddTransient<IPatchOrderService, PatchOrderService>();
            services.AddTransient<IDeleteOrderService, DeleteOrderService>();

            services.AddTransient<IPutPriceService, PutPriceService>();
            services.AddTransient<IPostPriceService, PostPriceService>();
            services.AddTransient<IPatchPriceService, PatchPriceService>();
            services.AddTransient<IDeletePriceService, DeletePriceService>();

            services.AddTransient<IPutSectorService, PutSectorService>();
            services.AddTransient<IPostSectorService, PostSectorService>();
            services.AddTransient<IPatchSectorService, PatchSectorService>();
            services.AddTransient<IDeleteSectorService, DeleteSectorService>();

            services.AddTransient<IPutStockService, PutStockService>();
            services.AddTransient<IPostStockService, PostStockService>();
            services.AddTransient<IPatchStockService, PatchStockService>();
            services.AddTransient<IDeleteStockService, DeleteStockService>();

            services.AddTransient<IPutStopService, PutStopService>();
            services.AddTransient<IPostStopService, PostStopService>();
            services.AddTransient<IPatchStopService, PatchStopService>();
            services.AddTransient<IDeleteStopService, DeleteStopService>();

            services.AddTransient<IPutSubSectorService, PutSubSectorService>();
            services.AddTransient<IPostSubSectorService, PostSubSectorService>();
            services.AddTransient<IPatchSubSectorService, PatchSubSectorService>();
            services.AddTransient<IDeleteSubSectorService, DeleteSubSectorService>();

            services.AddTransient<IPutWalletService, PutWalletService>();
            services.AddTransient<IPostWalletService, PostWalletService>();
            services.AddTransient<IPatchWalletService, PatchWalletService>();
            services.AddTransient<IDeleteWalletService, DeleteWalletService>();

            return services;
        }
    }
}
