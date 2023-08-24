using Backend.Entities;
using Backend.Interfaces;
using democode.DTO;

namespace Backend.Repositories
{
    public class AdminRepository:IAdminRepository
    {
        private readonly DBContext _dbconnect;
        public AdminRepository(DBContext _dbconnect)
        {
            this._dbconnect =_dbconnect;    
        }
        public Admin GetAdmin(string id)
        {
            var adminmaster = _dbconnect.Admin.FirstOrDefault(x => x.emp_id == id);
            return adminmaster;
        }
        public Admin LoginAdmin(AdminLoginDTO adminLoginDTO)
        {
            var adminmaster = _dbconnect.Admin.FirstOrDefault(x => x.emp_id == adminLoginDTO.id);
            return adminmaster;
        }
        public void AddAdmin(Admin admin)
        {
            _dbconnect.Admin.Add(admin);
            _dbconnect.SaveChanges();
        }
    }
}
