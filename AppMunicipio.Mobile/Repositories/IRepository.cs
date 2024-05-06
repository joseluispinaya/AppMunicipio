namespace AppMunicipio.Mobile.Repositories
{
    public interface IRepository
    {
        //Task<Response> GetTaxiAsync(string plaque, string urlBase, string servicePrefix, string controller);

        Task<HttpResponseWrapper<T>> GetPerso<T>(string ci, string urlBase, string servicePrefix, string controller);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string urlBase, string url, T model);
    }
}
