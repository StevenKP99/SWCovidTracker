using CovidTracker.Application.Models;
using CovidTracker.Domain;
using CovidTracker.Domain.V1State;

namespace CovidTracker.Application;

public static class Mapping
{
    public static StateCovidData MapToStateCovidData(this Data datum)
    {
        return new StateCovidData
        {
            State = datum.State,
            Positive = datum.Tests.Pcr.People.Positive.Value ?? 0,
            Negative = datum.Tests.Pcr.People.Negative.Value ?? 0,
            HospitalizedCurrently = datum.Outcomes.Hospitalized.Currently.Value ?? 0,
            HospitalizedInIcu = datum.Outcomes.Hospitalized.InIcu.Total.Value ?? 0,
            HospitalizedOnVentilator = datum.Outcomes.Hospitalized.OnVentilator.Total.Value ?? 0,
            Total = datum.Cases.Total.Value ?? 0,
            DataDate = datum.Date
        };
    }

    public static List<StateCovidData> MapToStateCovidData(this IEnumerable<Data> data)
    {
        return data.Select(d => d.MapToStateCovidData()).ToList();
    }

    public static StateCovidData MapToStateCovidData(this StateCovidRecord record)
    {
        //int total = record.HospitalizedCurrently ?? 0
        //     + record.InIcuCurrently ?? 0
        //     + record.OnVentilatorCurrently ?? 0;
        return new StateCovidData
        {
            State = record.State,
            Positive = record.Positive ?? 0,
            Negative = record.Negative ?? 0,
            HospitalizedCurrently = record.HospitalizedCurrently ?? 0,
            HospitalizedInIcu = record.InIcuCurrently ?? 0,
            HospitalizedOnVentilator = record.OnVentilatorCurrently ?? 0,
            Total = record.Total ?? record.PosNeg ?? 0,
            DataDate = record.Date
        };
    }

    public static List<StateCovidData> MapToCovidStateCovidData(this IEnumerable<StateCovidRecord> records)
    {
        return records.Select( s => s.MapToStateCovidData()).ToList();
    }
}
