using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Egen.Config
{
    public class ConfigManager
    {
        private readonly Dictionary<string, object>? _configData;

        public ConfigManager(string configFilePath)
        {
            string configJson = File.ReadAllText(configFilePath);
            _configData = JsonConvert.DeserializeObject<Dictionary<string, object>>(configJson);
        }

        public T? GetModuleConfig<T>(string moduleName) where T : IModuleConfig
        {
            if (_configData == null)
            {
                return default;
            }

            if (_configData.TryGetValue("Modules", out var modules) && modules is JObject modulesDict)
            {
                if (modulesDict.TryGetValue(moduleName, out var module) && module is JObject moduleJObject)
                {
                    return moduleJObject.ToObject<T>();
                }
            }

            return default;
        }
    }
}
