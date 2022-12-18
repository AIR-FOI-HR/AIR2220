using Breadr.Service.Gate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Gate
{
    public interface IGateService
    {
        Task<GatesResponse> GetAllGates(GatesRequest request);
        Task<GatesResponse> GetAllActiveGates(GatesRequest request);
        Task<GatesResponse> GetAllInactiveGates(GatesRequest request);
        Task<GateResponse> AddNewGate(GateRequest request);
        Task<GateResponse> EditGate(GateRequest request);
        Task<GateResponse> DisableGate(GateRequest request);
        Task<GateResponse> EnableGate(GateRequest request);
    }
}
