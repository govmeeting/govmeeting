using Microsoft.eShopWeb.ApplicationCore.Features.BasketNS;
using Moq;
using System.Threading.Tasks;
using Xunit;

using GM.ApplicationCore.Interfaces;
using GM.ApplicationCore.Entities.GovBodies;


namespace Microsoft.eShopWeb.UnitTests.GmTests
{
    class GovbodyTests
    {
        private readonly Mock<IAsyncRepository<GovBody>> _mockGovbodyRepo;

        public GovbodyTests()
        {
            _mockGovbodyRepo = new Mock<IAsyncRepository<GovBody>>();
        }
    }
}
