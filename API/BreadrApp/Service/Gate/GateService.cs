using Breadr.Service.Gate.Dtos;
using Breadr.Service.Gate.Models;
using DataAccess.DBContext;
using Service.Report.Dtos;
using Service.Report.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Gate
{
    public class GateService : IGateService
    {

        private readonly BreadrDbContext _context;

        public GateService(BreadrDbContext context)
        {
            _context = context;

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
                Active = x.Active

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

        public Task<GateResponse> AddNewGate(GateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GateResponse> DisableGate(GateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GateResponse> EditGate(GateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GateResponse> EnableGate(GateRequest request)
        {
            throw new NotImplementedException();
        }


    }
}
