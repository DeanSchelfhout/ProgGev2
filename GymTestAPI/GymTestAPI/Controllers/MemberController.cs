using GymTestAPI.DTO;
using GymTestBL.Interfaces;
using GymTestBL.Models;
using GymTestBL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;

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

        [Route("{id}")]
        [HttpGet]
        public Member Get(int id)
        {
            return RepoService.GetMember(id);
        }

        [HttpGet]
        public List<Member> GetAll()
        {
            return RepoService.GetAllMembers();
        }

        [HttpPost]
        public Member Add([FromBody] MemberDTO dataIn)
        {
            Member member = new Member
                (
                null,
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
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            RepoService.DeleteMember(id);
            return true;
        }
        [Route("{id}")]
        [HttpPut]
        public Member Update(int id, [FromBody] MemberDTO dataIn)
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
        [Route("Sessions/{id}")]
        [HttpGet]
        public IActionResult GetSessions(int id, int month, int year)
        {
            return Ok(RepoService.GetSessions(id, month, year));
        }
        [Route("SessionsCount/{id}")]
        [HttpGet]
        public IActionResult GetTotalSessionCount(int id, int year)
        {
            try
            {
                return Ok(RepoService.GetTotalSessionCount(id, year));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [Route("SessionsCountDetailed/{id}")]
        [HttpGet]
        public IActionResult GetTotalSessionCountDetailed(int id, int year)
        {
            try
            {
                return Ok(RepoService.GetTotalSessionCountDetailed(id, year));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [Route("SessionsStatistics/{id}")]
        [HttpGet]
        public IActionResult GetSessionsStatistics(int id)
        {
            try
            {
                return Ok(RepoService.GetSessionsStatistics(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [Route("CyclingSessionMonthly/{id}")]
        [HttpGet]
        public IActionResult GetCyclingSessionMonthly(int id, int year)
        {
            try
            {
                return Ok(RepoService.GetCyclingSessionMonthly(id, year));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
