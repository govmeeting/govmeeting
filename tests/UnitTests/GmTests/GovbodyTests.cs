using Moq;
using System.Threading.Tasks;
using Xunit;

using GM.ApplicationCore.Interfaces;
using GM.ApplicationCore.Entities.Govbodies;


namespace GM.UnitTests.GmTests
{
    class GovbodyTests
    {
        private readonly Mock<IAsyncRepository<Govbody>> _mockGovbodyRepo;

        public GovbodyTests()
        {
            _mockGovbodyRepo = new Mock<IAsyncRepository<Govbody>>();
        }
    }
}
