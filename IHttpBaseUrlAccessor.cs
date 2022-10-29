namespace AccessingAspnetCoreBaseUrl;

public interface IHttpBaseUrlAccessor
{
    string? SiteUrlString { get; set; }
    string? GetHttpsUrl();
    string? GetHttpUrl();
}