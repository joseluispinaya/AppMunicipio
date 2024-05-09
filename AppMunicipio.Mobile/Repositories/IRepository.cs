namespace AppMunicipio.Mobile.Repositories
{
    public interface IRepository
    {
        //Task<Response> GetTaxiAsync(string plaque, string urlBase, string servicePrefix, string controller);

        Task<HttpResponseWrapper<T>> GetPerso<T>(string ci, string urlBase, string servicePrefix, string controller);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string urlBase, string url, T model);
        Task<HttpResponseWrapper<T>> Get<T>(string urlBase, string url, string tokenType, string accessToken);
        //Task<Response> GetTripAsync(string urlBase, string servicePrefix, string controller, int id, string tokenType, string accessToken);
    }
}
