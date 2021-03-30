using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

public static class ApiCommonActions
{

    public static T DeserilizeJsonCamelCase<T>(string jsonString)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        T t;
        try
        {
            t = JsonConvert.DeserializeObject<T>(jsonString, settings);
        }
        catch (JsonSerializationException)
        {
            t = default;
        }

        return t;
    }

    public static string SerilizeToJsonCamelCase(object body)
    {
        var serializerSettings = new JsonSerializerSettings();
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
        serializerSettings.ContractResolver = contractResolver;
        return JsonConvert.SerializeObject(body, serializerSettings);
    }

    public static string SerilizeToJson(object body)
    {
        return JsonConvert.SerializeObject(body);
    }

    public static List<T> DeserializeToList<T>(string content)
    {
        return JsonConvert.DeserializeObject<List<T>>(content);
    }

    public static T DeserializeGwswData<T>(string json)
    {
        var completeObject = JObject.Parse(json);

        var gwswData = completeObject.Children().FirstOrDefault(x => x.Path.Equals("gwsw"));

        if (gwswData == null) return ApiCommonActions.DeserilizeJsonCamelCase<T>(json);

        var objectsData = gwswData.Children().First();

        return objectsData.ToObject<T>();
    }
}

