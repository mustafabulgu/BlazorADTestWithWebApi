using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using static BlazorApp.Pages.FetchData;
using System.Net.Http.Json;

namespace BlazorApp
{    /// <summary>
     /// We add the token manually in this class
     /// </summary>
    public class GetForecastDataWithToken : IGetForecastDataWithToken
    {

        public IAccessTokenProvider AccessTokenProvider { get; set; }

        private readonly HttpClient _httpClient;
        public GetForecastDataWithToken(IAccessTokenProvider accessTokenProvider, HttpClient httpClient)
        {
            _httpClient = httpClient;
             AccessTokenProvider = accessTokenProvider;
        }
        public async Task<WeatherForecast[]> GetWeatherForecasts()
        {
            var tokenResult = await AccessTokenProvider.RequestAccessToken();
            if (tokenResult.TryGetToken(out AccessToken token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Bearer", token.Value);
                return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            }
            return null;
        }
    }

    public interface IGetForecastDataWithToken
    {
        Task<WeatherForecast[]> GetWeatherForecasts();
    }
}
