using Newtonsoft.Json;

namespace UtilityHelper
{
  public static class Deserialize
  {
    public static T DeserializeToObject<T>(string jsonString)
    {
      return JsonConvert.DeserializeObject<T>(jsonString);
    }
  }
}
