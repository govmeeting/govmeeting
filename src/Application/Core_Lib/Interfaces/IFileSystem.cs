using System.Threading.Tasks;

namespace GM.Application.AppCore.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64);
    }
}
