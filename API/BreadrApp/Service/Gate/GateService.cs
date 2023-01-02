using Breadr.Service.Gate.Dtos;
using Breadr.Service.Gate.Models;
using DataAccess.DBContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Breadr.Service.Gate
{
    public class GateService : IGateService
    {

        private readonly BreadrDbContext _context;
        private readonly IMapper _mapper;

        public GateService(BreadrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<GatesResponse> GetAllGates(GatesRequest request)
        {
            GatesResponse response = new GatesResponse()
            {
                Request = request
            };

            List<GateDto> gates = await _context.Gates.Select(x => new GateDto
            {
                GateId = x.GateId,
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Price = x.Price,
                Keepalive = x.Keepalive,
                Active = x.Active,
                SelledProductsToday = _context.Logs.Where(y => y.GateId == x.GateId 
                    && y.DateTime == DateTime.Today && y.Action.Equals("purchase made")).Count(),
                SelledProductsYesterday = _context.Logs.Where(y => y.GateId == x.GateId
                    && y.DateTime == DateTime.Today.AddDays(-1) && y.Action.Equals("purchase made")).Count()

        }).ToListAsync();

            response.Gates = gates;
            response.Success = true;

            return response;
        }

        public async Task<GatesResponse> GetAllActiveGates(GatesRequest request)
        {
            GatesResponse response = new GatesResponse()
            {
                Request = request
            };

            List<GateDto> gates = await _context.Gates.Where(x => x.Active == 1).Select(x => new GateDto
            {
                GateId = x.GateId,
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Price = x.Price,
                Keepalive = x.Keepalive,
                Active = x.Active

            }).ToListAsync();

            response.Gates = gates;
            response.Success = true;

            return response;
        }



        public async Task<GatesResponse> GetAllInactiveGates(GatesRequest request)
        {
            GatesResponse response = new GatesResponse()
            {
                Request = request
            };

            List<GateDto> gates = await _context.Gates.Where(x => x.Active == 0).Select(x => new GateDto
            {
                GateId = x.GateId,
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Price = x.Price,
                Keepalive = x.Keepalive,
                Active = x.Active

            }).ToListAsync();

            response.Gates = gates;
            response.Success = true;

            return response;
        }

        public async Task<GateResponse> AddNewGate(GateRequest request)
        {
            GateResponse response = new GateResponse()
            {
                Request = request
            };

            int count = _context.Gates.Count();
            count++;

            DataAccess.Models.Gate gate = new()
            {             
                GateId = DeclareIdOfGate(count),
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Price = request.Price,
                Keepalive = DateTime.Now,
                Active = 1
            };

            await _context.Gates.AddAsync(gate);
            await _context.SaveChangesAsync();

            Log log = new()
            {
                DateTime = DateTime.Now,
                GateId = gate.GateId,
                Action = "new gate created",
                UserId = request.UserId,
            };

            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();

            DataAccess.Models.Gate addedGate = await _context.Gates.Where(x => x.GateId == gate.GateId).FirstOrDefaultAsync();
            GateDto gateDto = _mapper.Map<DataAccess.Models.Gate, GateDto>(addedGate);

            response.Gate = gateDto;
            response.Success = true;

            return response;

        }

        public string DeclareIdOfGate(int count)
        {
            if(count <= 9)
            {
                return $"TG_00{count}";
            }
            else if (count >=10 && count<= 99)
            {
                return $"TG_0{count}";
            }
            else
            {
                return $"TG_{count}";
            }
        }

        public async Task<GateResponse> DisableGate(GateRequest request)
        {
            GateResponse response = new GateResponse()
            {
                Request = request
            };

            DataAccess.Models.Gate disableGate = await _context.Gates.Where(x => x.Active ==1 && x.GateId.Equals(request.GateId)).FirstOrDefaultAsync();
            disableGate.Active = 0;
            await _context.SaveChangesAsync();

            Log log = new()
            {
                DateTime = DateTime.Now,
                GateId = request.GateId,
                Action = "gate disabled",
                UserId = request.UserId,
            };
            await _context.SaveChangesAsync();

            GateDto gateDto = _mapper.Map<DataAccess.Models.Gate,GateDto>(disableGate);
            response.Gate = gateDto;
            response.Success = true;
            return response;

        }

        public async Task<GateResponse> EditGate(GateRequest request)
        {
            GateResponse response = new GateResponse()
            {
                Request = request
            };

            DataAccess.Models.Gate updateGate = await _context.Gates.Where(x => x.GateId.Equals(request.GateId)).FirstOrDefaultAsync();
            if (request.ProductName != null)
                updateGate.ProductName = request.ProductName;
            if (request.Quantity != null)
                updateGate.Quantity = request.Quantity;
            if (request.Latitude != null)
                updateGate.Latitude = request.Latitude;
            if (request.Longitude != null)
                updateGate.Longitude = request.Longitude;
            if (request.Price != null)
                updateGate.Price = request.Price;

            await _context.SaveChangesAsync();

            Log log = new()
            {
                DateTime = DateTime.Now,
                GateId = request.GateId,
                Action = "gate edited",
                UserId = request.UserId,
            };
            await _context.SaveChangesAsync();

            GateDto gateDto = _mapper.Map<DataAccess.Models.Gate,GateDto>(updateGate);
            response.Gate = gateDto;
            response.Success = true;
            return response;
        }

        public async Task<GateResponse> EnableGate(GateRequest request)
        {
            GateResponse response = new GateResponse()
            {
                Request = request
            };

            DataAccess.Models.Gate disableGate = await _context.Gates.Where(x => x.Active == 0 && x.GateId.Equals(request.GateId)).FirstOrDefaultAsync();
            disableGate.Active = 1;
            await _context.SaveChangesAsync();

            Log log = new()
            {
                DateTime = DateTime.Now,
                GateId = request.GateId,
                Action = "gate enabled",
                UserId = request.UserId,
            };
            await _context.SaveChangesAsync();

            GateDto gateDto = _mapper.Map<DataAccess.Models.Gate, GateDto>(disableGate);
            response.Gate = gateDto;
            response.Success = true;
            return response;
        }

        public async Task<GateResponse> GetGate(GateRequest request)
        {
            GateResponse response = new GateResponse()
            {
                Request = request
            };

            GateDto gateDto = await _context.Gates.Where(x => x.GateId.Equals(request.GateId))
                .Select(x => new GateDto
                {
                    GateId = x.GateId,
                    Active = x.Active,
                    Keepalive = x.Keepalive,
                    Latitude = x.Latitude,
                    Longitude=x.Longitude,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    Quantity=x.Quantity
                }).FirstOrDefaultAsync();

            response.Gate = gateDto;
            response.Success = true;
            return response;
        }
    }
}
