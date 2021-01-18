using AutoMapper;
using GM.Application.DTOs.Govbodies;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{
    public class GetGovbody_Query : IRequest<GovbodyDetails_Dto>
    {
    }
    public class GetGovbody_QueryHandler : IRequestHandler<GetGovbody_Query, GovbodyDetails_Dto>
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovbody_QueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GovbodyDetails_Dto> Handle(GetGovbody_Query request, CancellationToken cancellationToken)
        {
            var result = new GovbodyDetails_Dto();
            //var govbodies = await _context.Govbodies.Include(i => i.ScheduledMeetings).ToListAsync(); ;

            //if (govbodies != null)
            //{
            //    result = _mapper.Map<List<RegisterGovbodyDto>>(govbodies);
            //}

            return result;
        }

    }
}
