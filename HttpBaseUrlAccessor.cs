namespace AccessingAspnetCoreBaseUrl;

public class HttpBaseUrlAccessor : IHttpBaseUrlAccessor
{
    public string? SiteUrlString { get; set; } = string.Empty;

    public string? GetHttpsUrl()
    {
        var urls = SiteUrlString.Split(";");

        return urls.FirstOrDefault(g => g.StartsWith("https://"));
    }

    public string? GetHttpUrl()
    {
        var urls = SiteUrlString.Split(";");

        return urls.FirstOrDefault(g => g.StartsWith("http://"));
    }
}