using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace uSync.Migrations.Migrators;

[SyncMigrator("TeaCommerce.StockManagement")]
public class TeaCommerceStockMigrator : SyncPropertyMigratorBase
{

    /// <summary>
    ///  convert to Umbraco.Commerce.Stock
    /// </summary>
    public override string GetEditorAlias(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        return "Umbraco.Commerce.Stock";
    }
}