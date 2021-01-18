using AutoMapper;
using GM.Application.DTOs.GovLocations;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class GetGovLocation_Query : IRequest<GovLocationDetails_Dto>
    {
    }
    public class GetGovLocation_QueryHandler : IRequestHandler<GetGovLocation_Query, GovLocationDetails_Dto>
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovLocation_QueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GovLocationDetails_Dto> Handle(GetGovLocation_Query request, CancellationToken cancellationToken)
        {
            var result = new GovLocationDetails_Dto();
            //var govbodies = await _context.Govbodies.Include(i => i.ScheduledMeetings).ToListAsync(); ;

            //if (govbodies != null)
            //{
            //    result = _mapper.Map<List<RegisterGovbodyDto>>(govbodies);
            //}

            return result;
        }

    }
}
