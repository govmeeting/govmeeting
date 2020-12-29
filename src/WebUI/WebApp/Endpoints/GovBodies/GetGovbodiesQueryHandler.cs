using GM.Application.AppCore.Entities.Govbodies;
using GM.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GM.Application.DTOs.Govbodies;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{
    public class GetGovbodiesQueryHandler : IRequestHandler<GetGovbodiesQuery,
        IList<GovbodyDto>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovbodiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<GovbodyDto>> Handle(GetGovbodiesQuery request, CancellationToken cancellationToken)
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
