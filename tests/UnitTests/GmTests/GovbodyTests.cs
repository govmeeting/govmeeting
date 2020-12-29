using Moq;
using System.Threading.Tasks;
using Xunit;

using GM.Application.AppCore.Interfaces;
using GM.Application.AppCore.Entities.Govbodies;


namespace GM.Tests.UnitTests.GmTests
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
