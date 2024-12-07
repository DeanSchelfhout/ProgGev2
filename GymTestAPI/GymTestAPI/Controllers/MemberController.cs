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
        MemberService RepoService;
        public MemberController(MemberService memberService) 
        {
            RepoService = memberService;
        }

        [Route("GetMember/{id}")]
        [HttpGet]
        public Member Get(int id)
        {
            return RepoService.GetMember(id);
        }

        [Route("GetAll")]
        [HttpGet]
        public List<Member> GetAll()
        {
           return RepoService.GetAllMembers();
        }

        [Route("Add")]
        [HttpPost]
        public Member Add([FromBody] MemberDTO dataIn) 
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

            return RepoService.AddMember(member);
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            RepoService.DeleteMember(id);
            return true;
        }
        [Route("Update/{id}")]
        [HttpPut]
        public Member Update(int id,[FromBody] MemberDTO dataIn)
        {
            Member member = new Member
                (
                id,
                dataIn.FirstName,
                dataIn.LastName,
                dataIn.Email,
                dataIn.Address,
                dataIn.Birthday,
                dataIn.Interests,
                dataIn.MemberType
                );

            return RepoService.UpdateMember(member);
        }
    }
}
