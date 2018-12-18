using Newtonsoft.Json;

namespace ToyotaSpec.Objects
{
    public class TestData
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public static T ParseJson<T>(string jsonText)
        {
            return JsonConvert.DeserializeObject<T>(jsonText, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Populate
            });
        }
    }
}
