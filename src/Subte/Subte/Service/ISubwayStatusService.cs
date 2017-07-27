using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Subte
{
    public interface ISubwayStatusService
    {
        Task<IEnumerable<SubwayLine>> GetStatusAsync();
    }
}
