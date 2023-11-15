using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace uSync.Migrations.Migrators;

[SyncMigrator("Umbraco.EmailAddress")]
public class EmailAddressMigrator : SyncPropertyMigratorBase
{

    /// <summary>
    ///  convert to TextBox, no other config 
    /// </summary>
    public override string GetEditorAlias(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
        => Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TextBox;

}
