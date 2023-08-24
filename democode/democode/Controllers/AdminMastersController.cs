using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Repositories;
using democode.DTO;

namespace Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminMastersController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        
        public AdminMastersController(IAdminRepository _adminRepository)
        {
            this._adminRepository = _adminRepository;
        }
        [HttpGet]
        public ActionResult GetAdmin(string id)
        {
            try
            {
                var result = _adminRepository.GetAdmin(id);
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult LoginAdmin(AdminLoginDTO adminLoginDTO)
        {
            try
            {
                var result = _adminRepository.LoginAdmin(adminLoginDTO);
                if (result == null)
                {
                    return StatusCode(401, "Invalid Credentials");
                }
                else
                {
                    if (result.password == adminLoginDTO.password)
                    {
                        return StatusCode(200, result);
                    }
                    else
                    {
                        return StatusCode(401, "Invalid Credentials");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpPut]
        public ActionResult AddAdmin(Admin _adminMasters)
        {
            try
            {
                _adminRepository.AddAdmin(_adminMasters);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
