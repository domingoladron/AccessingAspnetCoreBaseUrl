namespace AccessingAspnetCoreBaseUrl.ApiClients;

public interface IValuesApiClient
{
    Task<List<string>?> GetValuesAsync();
}