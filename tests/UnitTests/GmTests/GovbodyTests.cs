using Microsoft.eShopWeb.ApplicationCore.Features.BasketNS;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;
using GM.DatabaseModel;

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
