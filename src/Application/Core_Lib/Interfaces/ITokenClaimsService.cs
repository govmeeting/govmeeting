using System.Threading.Tasks;

namespace GM.Application.AppCore.Interfaces
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }
}
