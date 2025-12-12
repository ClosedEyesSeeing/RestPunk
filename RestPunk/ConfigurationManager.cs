using Avalonia;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestPunk
{
    public class ConfigurationManager
    {
		public static bool IsDarkTheme => Application.Current?.ActualThemeVariant == ThemeVariant.Dark;

		public Config Configuration { get; private set; } = new Config();

		public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
		{
			WriteIndented = true
		};

		public ConfigurationManager(string pathToConfig = ".\\appSettings.json")
		{
			if (File.Exists(pathToConfig))
			{
				Load(pathToConfig);
			}
			else
			{
				LoadDefaults();
			}
		}

		private void LoadDefaults()
		{
			Configuration.CurrentTheme = "Dark";
			Configuration.CurrentCollectionPath = ".\\defaultCollection.json";			
		}

		private void Load(string pathToConfig)
		{
			var configText = File.ReadAllText(pathToConfig);
			var configDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(configText);
			
			if (configDictionary == null)
			{
				LoadDefaults();
				return;
			}

			if (configDictionary.ContainsKey("CurrentTheme"))
			{
				Configuration.CurrentTheme = configDictionary["CurrentTheme"];
			}

			if (configDictionary.ContainsKey("CurrentCollectionPath"))
			{
				Configuration.CurrentCollectionPath = configDictionary["CurrentCollectionPath"];
			}			
		}

		public void Save()
		{			
			var configJson = JsonSerializer.Serialize(Configuration, JsonOptions);
			File.WriteAllText("appSettings.json", configJson);
		}		
	}
}
