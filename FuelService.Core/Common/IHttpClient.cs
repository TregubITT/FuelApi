namespace FuelService.Core.Common
{
    public interface IHttpClient
    {
        string GetResponceFromApi(string uri);
    }
}