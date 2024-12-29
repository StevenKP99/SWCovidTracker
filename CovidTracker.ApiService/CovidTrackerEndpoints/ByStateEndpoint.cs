using CovidTracker.Application.Models;
using CovidTracker.Application.Queries.StateRecords;
using FastEndpoints;
using MediatR;

namespace CovidTracker.ApiService.CovidTrackerEndpoints;

public record CovidStateRecordsByState(string State, DateTime? DataDate);
internal class ByStateEndpoint : Endpoint<CovidStateRecordsByState, List<StateCovidData>>
{
    private readonly IMediator _mediator;
    public ByStateEndpoint(IMediator mediat) {
        _mediator = mediat;
    }

    public override void Configure()
    {
        Get("/covidtracker");            
        AllowAnonymous();
    }

    public override async Task HandleAsync(CovidStateRecordsByState request, CancellationToken token = default)
    {
        var data = await _mediator.Send(new GetCovidDataByStateRequest(request.State, request.DataDate));

        await SendAsync(data);
    }
}
