using GymTestBL.Models;
using GymTestBL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        MemberService memberService;

        [HttpGet]
        public List<Member> GetAll()
        {
            return memberService.GetAllMembers();
        }
    }
}
