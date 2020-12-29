using Ardalis.GuardClauses;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace GM.Application.AppCore.Entities.Govbodies
{
    class GovbodyService
    {
        private readonly IAsyncRepository<Govbody> _govbodyRepository;
        private readonly IAppLogger<GovbodyService> _logger;

        public GovbodyService(IAsyncRepository<Govbody> govbodyRepository,
            IAppLogger<GovbodyService> logger)
        {
            _govbodyRepository = govbodyRepository;
            _logger = logger;
        }

        public async Task AddMeetingToGovbody(
            int govbodyId, string name, DateTime dateTime,
            string language, SourceType sourceType, string sourceFilename)
        {
            var govbodySpec = new GovbodyWithMeetingsSpecification(govbodyId);
            var govbody = await _govbodyRepository.FirstOrDefaultAsync(govbodySpec);
            Guard.Against.NullGovbody(govbodyId, govbody);

            govbody.AddMeeting(name, dateTime, language, sourceType, sourceFilename);

            await _govbodyRepository.UpdateAsync(govbody);
        }

    }
}
