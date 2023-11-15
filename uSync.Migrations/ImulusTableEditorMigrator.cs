using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace uSync.Migrations.Migrators;

[SyncMigrator("Imulus.TableEditor")]
public class ImulusTableEditorMigrator : SyncPropertyMigratorBase
{

    /// <summary>
    ///  convert to Umbraco.Commerce.StorePicker
    /// </summary>
    public override string GetEditorAlias(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        return "TableEditor";
    }
}