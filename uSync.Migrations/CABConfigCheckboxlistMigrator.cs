using Newtonsoft.Json;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Extensions;
using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace uSync.Migrations.Migrators;

[SyncMigrator("CAB.ConfigCheckboxlist")]
public class ConfigCheckboxlistMigrator : SyncPropertyMigratorBase
{

    /// <summary>
    ///  convert to Dropdown or theme ThemeDecorationPicker
    /// </summary>
    public override string GetEditorAlias(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        return Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.CheckBoxList;
    }

    public override object GetConfigValues(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        var config = new ValueListConfiguration();
        return config;
    }

    public override string GetContentValue(SyncMigrationContentProperty contentProperty, SyncMigrationContext context)
        => string.IsNullOrWhiteSpace(contentProperty.Value)
            ? contentProperty.Value
            : JsonConvert.SerializeObject(contentProperty.Value.ToDelimitedList(), Formatting.Indented);
}
