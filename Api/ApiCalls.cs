using RestSharp;

public class ApiCalls
{
    public static RestResponse Get(string resourcePath)
    {
        Utility.Request.Method = Method.GET;
        Utility.Request.Resource = resourcePath;
        Utility.Request.Body = null;
        return Utility.Client.Execute(Utility.Request) as RestResponse;
    }

    public static RestResponse Get(string resourcePath, string paramKey, string paramValue)
    {
        Utility.Request.Method = Method.GET;
        Utility.Request.Resource = resourcePath;
        Utility.Request.Body = null;
        Utility.Request.AddParameter(paramKey, paramValue);
        return Utility.Client.Execute(Utility.Request) as RestResponse;
    }

    public static RestResponse Post(string resourcePath, object body)
    {
        Utility.Request.Method = Method.POST;
        Utility.Request.Resource = resourcePath;
        Utility.Request.Body = null;

        Utility.Request.AddParameter("application/json", ApiCommonActions.SerilizeToJson(body), ParameterType.RequestBody);
        RestResponse response = Utility.Client.Execute(Utility.Request) as RestResponse;

        //cleanup for other calls
        Utility.Request.Parameters.RemoveAll(x => x.Type == ParameterType.RequestBody);

        return response;
    }

    public static RestResponse Post(string resourcePath)
    {
        Utility.Request.Method = Method.POST;
        Utility.Request.Resource = resourcePath;
        Utility.Request.Body = null;
        Utility.Request.AddParameter("application/json", ParameterType.RequestBody);
        RestResponse response = Utility.Client.Execute(Utility.Request) as RestResponse;

        //cleanup for other calls
        Utility.Request.Parameters.RemoveAll(x => x.Type == ParameterType.RequestBody);

        return response;
    }

    public static RestResponse Put(string resourcePath, object body)
    {
        Utility.Request.Method = Method.PUT;
        Utility.Request.Resource = resourcePath;
        Utility.Request.Body = null;

        Utility.Request.AddParameter("application/json", ApiCommonActions.SerilizeToJson(body), ParameterType.RequestBody);
        RestResponse response = Utility.Client.Execute(Utility.Request) as RestResponse;

        //cleanup for other calls
        Utility.Request.Parameters.RemoveAll(x => x.Type == ParameterType.RequestBody);
        return response;
    }

    public static RestResponse Delete(string resourcePath, string paramKey, string paramValue)
    {
        Utility.Request.Method = Method.DELETE;
        Utility.Request.Resource = resourcePath;
        Utility.Request.AddParameter(paramKey, paramValue);

        return Utility.Client.Execute(Utility.Request) as RestResponse;
    }
}

