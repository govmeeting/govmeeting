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
    public class GetGovbodies_Query : IRequest<IList<Govbody_Dto>>
    {
    }

    public class GetGovbodies_QueryHandler : IRequestHandler<GetGovbodies_Query,
        IList<Govbody_Dto>>
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovbodies_QueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<Govbody_Dto>> Handle(GetGovbodies_Query request, CancellationToken cancellationToken)
        {
            var result = new List<Govbody_Dto>();
            var govbodies = await _context.Govbodies.Include(i => i.ScheduledMeetings).ToListAsync(); ;

            if (govbodies != null)
            {
                result = _mapper.Map<List<Govbody_Dto>>(govbodies);
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
