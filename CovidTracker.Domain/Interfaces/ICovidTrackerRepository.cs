using CovidTracker.Domain.V1State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidTracker.Domain.Interfaces;

public interface ICovidTrackerRepository
{
    public Task<List<Data>> GetCovidDataByState(string state = "", DateTime? dataDate = null);

    public Task<List<StateCovidRecord>> GetAllStateCovidRecords();
}
