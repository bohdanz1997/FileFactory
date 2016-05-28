using FileObmen.Models.Repository;

namespace FileObmen.Models
{
    public interface IUnitOfWork
    {
        FileRepository Files { get; }
        UserRepository Users { get; }
        RoleRepository Roles { get; }
        PlanRepository Plans { get; }
        SettingsRepository Settings { get; }

        void SaveChanges();
    }
}