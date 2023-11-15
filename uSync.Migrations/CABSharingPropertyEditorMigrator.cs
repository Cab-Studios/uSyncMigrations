using Umbraco.Cms.Core.PropertyEditors;
using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace uSync.Migrations.Migrators;

[SyncMigrator("CAB.SharingPropertyEditor")]
public class CABSharingPropertyEditorMigrator : SyncPropertyMigratorBase
{

    /// <summary>
    ///  no change 
    /// </summary>
    public override string GetEditorAlias(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
        => "CAB.SharingPropertyEditor";

}
