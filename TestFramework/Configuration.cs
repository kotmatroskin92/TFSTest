using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;

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

        [DefaultValue(typeof(TimeSpan), "00:01:30")]
        public TimeSpan DefaultWaitTimeout { get; set; }

        [DefaultValue(typeof(TimeSpan), "00:01:30")]
        public TimeSpan DefaultCommandTimeout { get; set; }

        [DefaultValue(typeof(TimeSpan), "00:00:30")]
        public TimeSpan IsPresentTimeout { get; set; }

        [JsonProperty("browser.name")]
        public Browser Browser { get; set; }

        [JsonProperty("browser.headless")]
        public bool IsHeadless { get; set; }

        [DefaultValue("")]
        public string RemoteWebDriverUri { get; set; }

        public static T ParseConfiguration<T>(string jsonText) where T : IConfiguration
        {
            return JsonConvert.DeserializeObject<T>(jsonText, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Populate
            });
        }
    }
}
