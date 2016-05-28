using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models
{
    public interface IRepository
    {
        #region Files

        IQueryable<File> Files { get; }
        void SaveFile(File file);
        File GetFile(int? fileId);
        File GetFile(string sha);
        File DeleteFile(string sha); 

        #endregion

        #region Users

        IQueryable<User> Users { get; }
        void SaveUser(User user);
        User GetUser(string name);
        User DeleteUser(string name);

        #endregion
    }
}