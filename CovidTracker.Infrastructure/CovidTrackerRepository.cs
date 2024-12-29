using CovidTracker.Domain;
using CovidTracker.Domain.Interfaces;
using CovidTracker.Domain.V1State;
using CovidTracker.Infrastructure.Converters;
using Serilog;
using System.Text.Json;

namespace CovidTracker.Infrastructure;

internal class CovidTrackerRepository : ICovidTrackerRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger _logger;
    private string baseUrl = "https://api.covidtracking.com/";

    JsonSerializerOptions options = new JsonSerializerOptions
    {
       // PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
        Converters = { new DateConverter() }
    };

    public CovidTrackerRepository(IHttpClientFactory httpClientFactory, ILogger logger) {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }
    public async Task<List<Data>> GetCovidDataByState(string state, DateTime? dataDate = null)
    {
        string trackerUrl = $"{baseUrl}v2/states/{state}";
        if ( !string.IsNullOrEmpty(state))
        {
            //TODO: Throw State required exception
        }
        if (dataDate != null)
        {
            trackerUrl += "/" + dataDate.Value.ToString("yyyy-MM-dd");
        }
        else
        {
            trackerUrl += "/daily";
        }
        trackerUrl += ".json";
        //trackerUrl = "https://api.covidtracking.com/v2/states/ca/daily.json";
       
        _logger.Information("GetCovidDataByState: {trackerUrl}", trackerUrl);

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(trackerUrl);

        if (response.IsSuccessStatusCode)
        {

            var data = response.Content.ReadAsStringAsync().Result;
            var covidData = JsonSerializer.Deserialize<Root>(data, options);
            

            if (covidData == null)
            {
                _logger.Error("GetCovidDataByState: {Data}", data);
                return new List<Data>();
            }

            return covidData.Data;
        }
        else
        {
            _logger.Error("GetCovidDataByState: {statusCode}", response.StatusCode);
            return new List<Data>();
        }
    }

    public async Task<List<StateCovidRecord>> GetAllStateCovidRecords()
    {
        string trackerUrl = baseUrl + "v1/states/daily.json";

        _logger.Information("GetCovidDataByState: {trackerUrl}", trackerUrl);

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(trackerUrl);

        if (response.IsSuccessStatusCode)
        {
          //  options.Converters.Add(new DateConverter());
            var data = response.Content.ReadAsStringAsync().Result;
            var covidData = JsonSerializer.Deserialize<List<StateCovidRecord>>(data, options);


            if (covidData == null)
            {
                _logger.Error("GetCovidDataByState: {Data}", data);
                return new List<StateCovidRecord>();
            }

            return covidData;
        }
        else
        {
            _logger.Error("GetCovidDataByState: {statusCode}", response.StatusCode);
            return new List<StateCovidRecord>();
        }
    }
}
