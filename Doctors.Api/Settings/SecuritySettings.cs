using Microsoft.AspNetCore.Server.IIS.Core;
using Newtonsoft.Json;
using System.Data;

namespace Doctors.Api.Settings;

public class SecuritySettings
{

    public string Ak { get; set; } = default!;
    public string Sk { get; set; } = default!;

    public static SecuritySettings GetSecuritySettings()
    {
        string file = "aksk.json";

        using StreamReader reader = new(file);
        var json = reader.ReadToEnd();
        var settings = JsonConvert.DeserializeObject<List<SecuritySettings>>(json);

        return settings == null ? throw new FileNotFoundException(file) : settings[0];
    }
}
