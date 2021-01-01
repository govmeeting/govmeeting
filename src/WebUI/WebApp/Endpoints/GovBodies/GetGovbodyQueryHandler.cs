using AutoMapper;
using GM.Application.DTOs.Govbodies;
using GM.Infrastructure.InfraCore.Data;
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
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovbodyQueryHandler(ApplicationDbContext context, IMapper mapper)
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

        //public GetGovbodyQueryHandler() { }
        //public async Task<IList<GovbodyDto>> Handle(GetGovbodyQuery request, CancellationToken cancellationToken)
        //{
        //    Task task = Task.Delay(1);
        //    await task;
        //    return null;
        //}

    }
}
