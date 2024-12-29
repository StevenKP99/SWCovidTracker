using CovidTracker.Application.Models;
using CovidTracker.Domain.Interfaces;
using MediatR;
using Serilog;

namespace CovidTracker.Application.Queries.StateRecords;

public record GetCovidDataByStateRequest(string state, DateTime? day = null) : IRequest<List<StateCovidData>>;

internal class GetCovidDataByStateHandler : IRequestHandler<GetCovidDataByStateRequest, List<StateCovidData>>
{
    private readonly ICovidTrackerRepository _repositories;
    private readonly ILogger _logger;

    public GetCovidDataByStateHandler(ICovidTrackerRepository repositories, ILogger logger)
    {
        _repositories = repositories;
        _logger = logger;
    }
    public async Task<List<StateCovidData>> Handle(GetCovidDataByStateRequest request, CancellationToken cancellationToken)
    {
        _logger.Information("GetCovidDataByStateRequest: {@request}", request);

        var data = await _repositories.GetCovidDataByState(request.state, request.day);

        return data.MapToStateCovidData();
    }
}
