using Breadr.Service.Gate.Models;

namespace Breadr.Service.Gate
{
    public interface IGateService
    {
        Task<GatesResponse> GetAllGates(GatesRequest request);
        Task<GateResponse> GetGate(GateRequest request);
        Task<GatesResponse> GetAllActiveGates(GatesRequest request);
        Task<GatesResponse> GetAllInactiveGates(GatesRequest request);
        Task<GateResponse> AddNewGate(GateRequest request);
        Task<GateResponse> EditGate(GateRequest request);
        Task<GateResponse> DisableGate(GateRequest request);
        Task<GateResponse> EnableGate(GateRequest request);
    }
}
