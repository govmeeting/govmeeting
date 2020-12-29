using AutoMapper;
using GM.Application.DTOs.GovLocations;
using GM.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class GetGovLocationQueryHandler : IRequestHandler<GetGovLocationQuery,
        IList<GovLocationDto>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovLocationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<GovLocationDto>> Handle(GetGovLocationQuery request, CancellationToken cancellationToken)
        {
            var result = new List<GovLocationDto>();
            var govbodies = await _context.Govbodies.Include(i => i.ScheduledMeetings).ToListAsync(); ;

            if (govbodies != null)
            {
                result = _mapper.Map<List<GovLocationDto>>(govbodies);
            }

            return result;
        }
    }
}
