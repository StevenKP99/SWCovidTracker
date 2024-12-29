using Ardalis.SmartEnum;

namespace CovidTracker.Application.Models;

public static class States 
{
    public static Dictionary<string, string> stateToAbbrev = new Dictionary<string, string>() { { "alabama", "AL" }, { "alaska", "AK" }, { "arizona", "AZ" }, { "arkansas", "AR" }, { "california", "CA" }, { "colorado", "CO" }, { "connecticut", "CT" }, { "delaware", "DE" }, { "district of columbia", "DC" }, { "florida", "FL" }, { "georgia", "GA" }, { "hawaii", "HI" }, { "idaho", "ID" }, { "illinois", "IL" }, { "indiana", "IN" }, { "iowa", "IA" }, { "kansas", "KS" }, { "kentucky", "KY" }, { "louisiana", "LA" }, { "maine", "ME" }, { "maryland", "MD" }, { "massachusetts", "MA" }, { "michigan", "MI" }, { "minnesota", "MN" }, { "mississippi", "MS" }, { "missouri", "MO" }, { "montana", "MT" }, { "nebraska", "NE" }, { "nevada", "NV" }, { "new hampshire", "NH" }, { "new jersey", "NJ" }, { "new mexico", "NM" }, { "new york", "NY" }, { "north carolina", "NC" }, { "north dakota", "ND" }, { "ohio", "OH" }, { "oklahoma", "OK" }, { "oregon", "OR" }, { "pennsylvania", "PA" }, { "rhode island", "RI" }, { "south carolina", "SC" }, { "south dakota", "SD" }, { "tennessee", "TN" }, { "texas", "TX" }, { "utah", "UT" }, { "vermont", "VT" }, { "virginia", "VA" }, { "washington", "WA" }, { "west virginia", "WV" }, { "wisconsin", "WI" }, { "wyoming", "WY" } };
    public static Dictionary<string, string> abbrevToState = new Dictionary<string, string>() { { "AK", "alaska" }, { "AL", "alabama" }, { "AR", "arkansas" }, { "AZ", "arizona" }, { "CA", "california" }, { "CO", "colorado" }, { "CT", "connecticut" }, { "DC", "district of columbia" }, { "DE", "delaware" }, { "FL", "florida" }, { "GA", "georgia" }, { "HI", "hawaii" }, { "IA", "iowa" }, { "ID", "idaho" }, { "IL", "illinois" }, { "IN", "indiana" }, { "KS", "kansas" }, { "KY", "kentucky" }, { "LA", "louisiana" }, { "MA", "massachusetts" }, { "MD", "maryland" }, { "ME", "maine" }, { "MI", "michigan" }, { "MN", "minnesota" }, { "MO", "missouri" }, { "MS", "mississippi" }, { "MT", "montana" }, { "NC", "north carolina" }, { "ND", "north dakota" }, { "NE", "nebraska" }, { "NH", "new hampshire" }, { "NJ", "new jersey" }, { "NM", "new mexico" }, { "NV", "nevada" }, { "NY", "new york" }, { "OH", "ohio" }, { "OK", "oklahoma" }, { "OR", "oregon" }, { "PA", "pennsylvania" }, { "RI", "rhode island" }, { "SC", "south carolina" }, { "SD", "south dakota" }, { "TN", "tennessee" }, { "TX", "texas" }, { "UT", "utah" }, { "VA", "virginia" }, { "VT", "vermont" }, { "WA", "washington" }, { "WI", "wisconsin" }, { "WV", "west virginia" }, { "WY", "wyoming" } };

    public static string? ConvertStateToAbbreviation(string stateName)
    {
        if (string.IsNullOrEmpty(stateName))
        {
            return null;
        }
        else if (stateName.Length == 2)
        {
            if (abbrevToState.ContainsKey(stateName.ToUpper()))
                return stateName.ToUpper();
            else
                return null;
        }
        else if (stateToAbbrev.ContainsKey(stateName.ToLower()))
        {
            return stateToAbbrev[stateName.ToLower()];
        }
        return null;
    }

    public static string? ConvertAbbreviationToState(string stateAbbrev)
    {
        if (string.IsNullOrEmpty(stateAbbrev))
        {
            return null;
        }
        else if (stateAbbrev.Length > 2)
        {
            return null;
        }
        else if (abbrevToState.ContainsKey(stateAbbrev.ToUpper()))
        {
            return abbrevToState[stateAbbrev.ToUpper()];
        }
        return null;
    }
}
