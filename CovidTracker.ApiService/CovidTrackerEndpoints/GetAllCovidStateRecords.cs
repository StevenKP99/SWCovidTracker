using CovidTracker.Application.Models;
using CovidTracker.Application.Queries.StateRecords;
using FastEndpoints;
using MediatR;

namespace CovidTracker.ApiService.CovidTrackerEndpoints;

public record GetAllCovidStateRecords();

public class GetAllCovidStateRecordEndpoint : EndpointWithoutRequest<List<StateCovidData>>
{
    private readonly IMediator _mediator;
    public GetAllCovidStateRecordEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/covidstaterecords");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken token = default)
    {
        var data = await _mediator.Send(new GetAllCovidStateRecordsRequest());

        await SendAsync(data);
    }
}
