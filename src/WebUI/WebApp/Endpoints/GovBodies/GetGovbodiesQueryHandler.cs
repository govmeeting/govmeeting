using GM.ApplicationCore.Entities.Govbodies;
using GM.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace GM.WebApp.Endpoints.GovBodies
{
    public class GetGovbodiesQueryHandler : IRequestHandler<GetGovbodiesQuery,
        IList<GovbodyVm>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovbodiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<GovbodyVm>> Handle(GetGovbodiesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<GovbodyVm>();
            var govbodies = await _context.GovBodies.Include(i => i.ScheduledMeetings).ToListAsync(); ;

            if (govbodies != null)
            {
                result = _mapper.Map<List<GovbodyVm>>(govbodies);
            }

            return result;
        }
    }
}
