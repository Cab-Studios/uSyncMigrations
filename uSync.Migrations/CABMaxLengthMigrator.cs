using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Extensions;
using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Extensions;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace uSync.Migrations.Migrators;

[SyncMigrator("CAB.MaxLength")]
public class CABMaxLengthMigrator : SyncPropertyMigratorBase
{

    /// <summary>
    ///  convert to TextBox with max length
    /// </summary>
    public override string GetEditorAlias(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        var multiLine = dataTypeProperty.PreValues.GetPreValueOrDefault("multiLine", false);
        if (multiLine)
        {
            return Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TextArea;
        }

        return Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TextBox;
    }

    public override object GetConfigValues(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        var config = new TextboxConfiguration();

        foreach (var preValue in dataTypeProperty.PreValues)
        {
            if (preValue.Alias.InvariantEquals("limit"))
            {
                if(int.TryParse(preValue.Value, out int intValue))
                {
                    config.MaxChars = intValue;
                }
            }
        }

        return config;
    }
}
