using AutoMapper;
using GM.Application.DTOs.Govbodies;
using GM.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{
    public class GetGovbodyQueryHandler : IRequestHandler<GetGovbodyQuery,
        IList<GovbodyDto>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovbodyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<GovbodyDto>> Handle(GetGovbodyQuery request, CancellationToken cancellationToken)
        {
            var result = new List<GovbodyDto>();
            var govbodies = await _context.Govbodies.Include(i => i.ScheduledMeetings).ToListAsync(); ;

            if (govbodies != null)
            {
                result = _mapper.Map<List<GovbodyDto>>(govbodies);
            }

            return result;
        }
    }
}
