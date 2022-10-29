namespace AccessingAspnetCoreBaseUrl.ApiClients;

public class ValuesApiClient : IValuesApiClient
{
    // You  can find the IHttpContextAccessor injected in the Program.cs
    //  builder.Services.AddHttpContextAccessor();
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ValuesApiClient(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<List<string>?> GetValuesAsync()
    {
        var httpClient = new HttpClient();
        var request = _httpContextAccessor.HttpContext!.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";

        httpClient.BaseAddress = new Uri(baseUrl);

        var results = await httpClient.GetAsync("values");

        var valuesFoundFromApi = await results.Content.ReadFromJsonAsync<List<string>>();

        return valuesFoundFromApi;

    }
}