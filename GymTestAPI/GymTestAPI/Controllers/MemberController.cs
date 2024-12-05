using GymTestAPI.DTO;
using GymTestBL.Interfaces;
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
        IMemberRepository Repo;
        public MemberController(IMemberRepository memberRepository) 
        { 
            Repo = memberRepository;
        }
        [HttpGet]
        public List<Member> GetAll()
        {
           return Repo.GetAllMembers();
        }

        [HttpPost]
        public void Post([FromBody] MemberDTO dataIn) 
        {
            Member member = new Member
                (
                dataIn.MemberId,
                dataIn.FirstName,
                dataIn.LastName,
                dataIn.Email,
                dataIn.Address,
                dataIn.Birthday,
                dataIn.Interests,
                dataIn.MemberType
                );

            Repo.AddMember(member);
        }
    }
}
