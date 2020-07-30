# BAYSOFT - StockWallet
Architecture CQRS FullAPI 

## Migrations
> dotnet tool install --global dotnet-ef

> dotnet add package Microsoft.EntityFrameworkCore.Design

> dotnet ef migrations add InitialStockWalletDbMigration -c StockWalletDbContext -o Migrations/StockWalletDb
