using Backend.Entities;
using democode.DTO;

namespace Backend.Interfaces
{
    public interface IAdminRepository
    {
        Admin GetAdmin(string id);
        void AddAdmin(Admin admin);
        Admin LoginAdmin(AdminLoginDTO adminLoginDTO);
    }
}
