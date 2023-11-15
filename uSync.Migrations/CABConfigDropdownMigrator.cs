using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Extensions;
using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Extensions;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace uSync.Migrations.Migrators;

[SyncMigrator("CAB.ConfigDropdown")]
public class ConfigDropdownMigrator : SyncPropertyMigratorBase
{
    private readonly ILogger<ConfigDropdownMigrator> _logger;

    public ConfigDropdownMigrator(ILogger<ConfigDropdownMigrator> logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///  convert to Dropdown or theme ThemeDecorationPicker
    /// </summary>
    public override string GetEditorAlias(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        var configFilename = dataTypeProperty.PreValues.GetPreValueOrDefault("filename", string.Empty);
        if (configFilename.InvariantEquals("themes"))
        {
            return "ThemeDecorationPicker";
        }

        return Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.DropDownListFlexible;
    }

    public override object GetConfigValues(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        var configFilename = dataTypeProperty.PreValues.GetPreValueOrDefault("filename", string.Empty);
        if (configFilename.InvariantEquals("themes"))
        {            
            return new Dictionary<string, object>();
        }
        else
        {
            return new DropDownFlexibleConfiguration();
        }
    }

    public override string GetContentValue(SyncMigrationContentProperty contentProperty, SyncMigrationContext context)
    {
        if (contentProperty.Value == "Beige" ||
            contentProperty.Value == "Beige testimonial" ||
            contentProperty.Value == "Black" ||
            contentProperty.Value == "Blue" ||
            contentProperty.Value == "Blue testimonial" ||
            contentProperty.Value == "Gray light" ||
            contentProperty.Value == "Gray light testimonial" ||
            contentProperty.Value == "Pink" ||
            contentProperty.Value == "Pink testimonial" ||
            contentProperty.Value == "White" ||
            contentProperty.Value == "White testimonial")
        {
            //var themeDecorations = new JArray();

            dynamic themeDecorationObject = new JObject();
            themeDecorationObject.label = contentProperty.Value;
            //themeDecorations.Add(themeDecorationObject);

            return JsonConvert.SerializeObject(themeDecorationObject);
        }
        else
        {
            if(string.IsNullOrWhiteSpace(contentProperty.Value))
            {
                return contentProperty.Value;
            }
            else
            {
                return JsonConvert.SerializeObject(contentProperty.Value.ToDelimitedList(), Formatting.Indented);
            }
        }
    }
}