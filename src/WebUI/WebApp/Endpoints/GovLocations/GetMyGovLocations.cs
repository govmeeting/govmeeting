using AutoMapper;
using GM.Application.AppCore.Interfaces;
using GM.Application.DTOs.GovLocations;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class GetMyGovLocations_Query : IRequest<List<GovLocation_Dto>>
    {
    }

    /// <summary>
    /// Handler class to get current user's GovLocations
    /// </summary>
    public class GetMyGovLocations_QueryHandler : IRequestHandler<GetMyGovLocations_Query,
        IList<GovLocation_Dto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        private readonly IMapper _mapper;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="currentUserService"></param>
        public GetMyGovLocations_QueryHandler(
            ApplicationDbContext context,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// Get current user's GovLocations
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IList<GovLocation_Dto>> Handle(GetMyGovLocations_Query request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId ?? string.Empty;

            var result = new List<GovLocation_Dto>();
            var govLocations = await _context.GovLocations.ToListAsync();

            if (govLocations != null)
            {
                result = _mapper.Map<List<GovLocation_Dto>>(govLocations);
            }

            return result;
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
