using CovidTracker.Application.Models;
using CovidTracker.Domain.Interfaces;
using MediatR;
using Serilog;

namespace CovidTracker.Application.Queries.StateRecords;

public record GetAllCovidStateRecordsRequest() : IRequest<List<StateCovidData>>;
internal class GetAllHandler : IRequestHandler<GetAllCovidStateRecordsRequest, List<StateCovidData>>
{
    private readonly ILogger _logger;
    private readonly ICovidTrackerRepository _repository;

    public GetAllHandler(ICovidTrackerRepository repository, ILogger logger)
    {
        _logger = logger;
        _repository = repository;
    }
    public async Task<List<StateCovidData>> Handle(GetAllCovidStateRecordsRequest request, CancellationToken cancellationToken)
    {
        _logger.Information("GetCovidDataByStateRequest: {@request}", request);

        var data = await _repository.GetAllStateCovidRecords();

        return data.MapToCovidStateCovidData().OrderByDescending(x => x.Positive).ToList();
    }
}
