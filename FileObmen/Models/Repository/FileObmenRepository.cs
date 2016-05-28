
namespace FileObmen.Models.Repository
{
    public partial class FileObmenRepository : IRepository
    {
        FileObmenContext db = new FileObmenContext();
    }
}