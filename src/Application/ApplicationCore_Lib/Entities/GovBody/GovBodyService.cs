using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Interfaces;

namespace GM.ApplicationCore.Entities.GovBodies
{
    class GovBodyService
    {
        private readonly IAsyncRepository<GovBody> _govbodyRepository;
        private readonly IAppLogger<GovBodyService> _logger;

        public GovBodyService(IAsyncRepository<GovBody> govbodyRepository,
            IAppLogger<GovBodyService> logger)
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
