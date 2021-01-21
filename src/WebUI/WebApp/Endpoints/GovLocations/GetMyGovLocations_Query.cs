using AutoMapper;
using GM.Application.AppCore.Entities.GovLocations;
using GM.Application.AppCore.Interfaces;
using GM.Application.DTOs.GovLocations;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class GetMyGovLocations_Query : IRequest<IEnumerable<GovLocation_Dto>>
    {
    }

    /// <summary>
    /// Handler class to get current user's GovLocations
    /// </summary>
    public class GetMyGovLocations_QueryHandler : IRequestHandler<GetMyGovLocations_Query,
        IEnumerable<GovLocation_Dto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        private readonly IMapper _mapper;

        public GetMyGovLocations_QueryHandler(
            ApplicationDbContext context,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<GovLocation_Dto>> Handle(GetMyGovLocations_Query request, CancellationToken cancellationToken)
        {
            //var userId = _currentUserService.UserId ?? string.Empty;

            // TODO Get current user's GovLocation ID - these are temporary for development
            int myloc_id = 13; 
            string mylocCity = "City of Whittlesea";

            //var result = new List<GovLocation_Dto>();

            IEnumerable<GovLocation> govlocs = _context.GovLocations.AsEnumerable();

            var govLocations = await _context.GovLocations.ToListAsync();
            //GovLocation myloc = govlocs.Where(l => l.Id == myloc_id).FirstOrDefault();
            GovLocation myloc = govlocs.Where(l => l.Name == mylocCity).FirstOrDefault();

            IEnumerable<GovLocation> ancestors = GetAncestors(myloc);

            IEnumerable<GovLocation_Dto> result = null;
            if (ancestors != null)
            {
                result = _mapper.Map<List<GovLocation_Dto>>(ancestors);
            }
            return result;
        }

        IEnumerable<GovLocation> GetAncestors(GovLocation loc)
        {
            yield return loc;
            GovLocation parent = loc.ParentLocation;
            while (parent != null)
            {
                yield return parent;
                parent = parent.ParentLocation;
            }
        }


        //public GetGovLocationQueryHandler(ApplicationDbContext context, IMapper mapper) { }
        //public async Task<IList<GovLocationDto>> Handle(GetGovLocationQuery request, CancellationToken cancellationToken)
        //{
        //    Task task = Task.Delay(1);
        //    await task;
        //    return null;
        //}


    }
}
