using System;
using System.ComponentModel;
using Newtonsoft.Json;
using TestFramework.WebDriver.enums;

namespace TestFramework
{
    public class Configuration : IConfiguration
    {
        [JsonProperty("browser.WindowHeight")]
        public int? WindowHeight { get; set; }

        [JsonProperty("browser.WindowWidth")]
        public int? WindowWidth { get; set; }

        [JsonProperty("browser.MaximizeWindow")]
        [DefaultValue(typeof(bool), "false")]
        public bool MaximizeWindow { get; set; }

        [DefaultValue(typeof(TimeSpan), "00:01:00")]
        public TimeSpan DefaultWaitTimeout { get; set; }

        [DefaultValue(typeof(TimeSpan), "00:01:10")]
        public TimeSpan DefaultDownloadTimeout { get; set; }

        [JsonProperty("browser.Name")]
        public Browser Browser { get; set; }

        [JsonProperty("browser.Headless")]
        [DefaultValue(typeof(bool), "false")]
        public bool IsHeadless { get; set; }

        [DefaultValue("")]
        public string StartPageUrl { get; set; }

        [DefaultValue("{currentDir}\\screenshots")]
        public string ScreenshotFolder { get; set; }

        [DefaultValue("C:\\Autotest\\downloads")]
        public string DownloadsFolder { get; set; }

        [DefaultValue("{currentDir}")]
        public string WebDriverFolder { get; set; }

        public static T ParseConfiguration<T>(string jsonText) where T : IConfiguration
        {
            return JsonConvert.DeserializeObject<T>(jsonText, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Populate
            });
        }
    }
}
