using Common.Models;
using RestSharp;

public static class CallBase
{
    public static string TokenValue;
    private static readonly string clientUrl = "";
    private static readonly string loginUrl = "";
    private static readonly string clientId = "";
    private static readonly string scope = "";
    private static readonly string clientSecret = "";
    private static readonly string password = "";
    private static readonly string grant_type = "";
    private static readonly string testUser = "";

    private const string TEST_URL = "";

    private static void SetTokenValue()
    {
        Utility.Request = new RestRequest(loginUrl, Method.POST);
        Utility.Client = new RestClient(clientUrl);

        Utility.Request.AddParameter("client_id", clientId, ParameterType.GetOrPost);
        Utility.Request.AddParameter("grant_type", grant_type, ParameterType.GetOrPost);
        Utility.Request.AddParameter("client_secret", clientSecret, ParameterType.GetOrPost);
        Utility.Request.AddParameter("scope", scope, ParameterType.GetOrPost);
        Utility.Request.AddParameter("username", testUser, ParameterType.GetOrPost);
        Utility.Request.AddParameter("password", password, ParameterType.GetOrPost);

        Utility.Response = Utility.Client.Execute(Utility.Request) as RestResponse;

        TokenValue = ApiCommonActions.DeserilizeJsonCamelCase<LoginResponseBodyModel>(Utility.Response.Content).Id_token;
    }

    public static void LoginAndSetToken()
    {
        SetTokenValue();
        Utility.Request = new RestRequest();
        Utility.Client = new RestClient(TEST_URL);
        Utility.Request.AddParameter("Authorization", "Bearer " + TokenValue, ParameterType.HttpHeader);
    }
}