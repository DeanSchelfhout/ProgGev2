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
        [Route("Delete/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            RepoService.DeleteMember(id);
            return true;
        }
        [Route("Update/{id}")]
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
        [Route("GetSessions/{id}")]
        [HttpGet]
        public SessionsDTO GetSessions(int id, int month, int year)
        {
            Member member = RepoService.GetMember(id);
            SessionsDTO sessions = new SessionsDTO();

            if (member.CyclingSessions != null)
            {
                sessions.CyclingSessions = (List<CyclingSession>)member.CyclingSessions.Where(m => m.Date.Month == month && m.Date.Year == year).OrderBy(m => m.Date).ToList();
            }
            if (member.RunningSessions != null)
            {
                sessions.runningSessions = (List<RunningSessionMain>)member.RunningSessions.Where(m => m.Date.Month == month && m.Date.Year == year).OrderBy(m => m.Date).ToList();
            }
            if (sessions == null)
            {
                throw new Exception("This member doesn't have any sessions");
            }
            return sessions;
        }
        [Route("SessionsCount/{id}")]
        [HttpGet]
        public IActionResult GetTotalSessionCount(int id, int year)
        {
            Member member = RepoService.GetMember(id);

            if (member.RunningSessions == null && member.CyclingSessions == null)
            {
                return NotFound(new { message = "This member doesn't have any sessions" });
            }
            else
            {

                List<SessionCountByMonthDTO> sessionCountByMonthList = new List<SessionCountByMonthDTO>();
                for (int i = 1; i < 13; i++)
                {
                    SessionCountByMonthDTO sessionCountByMonth = new SessionCountByMonthDTO();
                    int counter = 0;
                    for (int j = 0; j < member.RunningSessions.Count; j++)
                    {
                        if (member.RunningSessions[j].Date.Month == i && member.RunningSessions[j].Date.Year == year)
                        {
                            counter++;
                        }
                    }
                    for (int j = 0; j < member.CyclingSessions.Count; j++)
                    {
                        if (member.CyclingSessions[j].Date.Month == i && member.CyclingSessions[j].Date.Year == year)
                        {
                            counter++;
                        }
                    }
                    if (counter != 0)
                    {
                        sessionCountByMonth.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                        sessionCountByMonth.SessionCount = counter;
                        sessionCountByMonthList.Add(sessionCountByMonth);
                    }
                }
                return Ok(sessionCountByMonthList);
            }
        }
        [Route("SessionsCountDetailed/{id}")]
        [HttpGet]
        public IActionResult GetTotalSessionCountDetailed(int id, int year)
        {
            Member member = RepoService.GetMember(id);

            if (member.RunningSessions == null && member.CyclingSessions == null)
            {
                return NotFound(new { message = "This member doesn't have any sessions" });
            }
            else
            {

                List<SessionCountByMonthDetailedDTO> sessionCountByMonthList = new List<SessionCountByMonthDetailedDTO>();
                for (int i = 1; i < 13; i++)
                {
                    SessionCountByMonthDetailedDTO sessionCountByMonth = new SessionCountByMonthDetailedDTO();
                    int runningCounter = 0;
                    int cyclingCounter = 0;
                    for (int j = 0; j < member.RunningSessions.Count; j++)
                    {
                        if (member.RunningSessions[j].Date.Month == i && member.RunningSessions[j].Date.Year == year)
                        {
                            runningCounter++;
                        }
                    }
                    for (int j = 0; j < member.CyclingSessions.Count; j++)
                    {
                        if (member.CyclingSessions[j].Date.Month == i && member.CyclingSessions[j].Date.Year == year)
                        {
                            cyclingCounter++;
                        }
                    }
                    if (runningCounter + cyclingCounter != 0)
                    {
                        sessionCountByMonth.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                        if (runningCounter != 0)
                        {
                            sessionCountByMonth.RunningSessionCount = runningCounter;
                        }
                        if (cyclingCounter != 0)
                        {
                            sessionCountByMonth.CyclingSessionCount = cyclingCounter;
                        }
                        sessionCountByMonthList.Add(sessionCountByMonth);
                    }
                }
                return Ok(sessionCountByMonthList);
            }
        }
        [Route("GetSessionsStatistics/{id}")]
        [HttpGet]
        public SessionsStatisticsDTO GetSessionsStatistics(int id)
        {
            Member member = RepoService.GetMember(id);
            SessionsStatisticsDTO sessionsStatistics = new SessionsStatisticsDTO();
            if (member.CyclingSessions != null || member.RunningSessions != null)
            {
                var shortestCyclingSession = member.CyclingSessions.OrderBy(m => m.Duration).FirstOrDefault();
                var longestCyclingSession = member.CyclingSessions.OrderByDescending(m => m.Duration).FirstOrDefault();
                var shortestRunningSession = member.RunningSessions.OrderBy(m => m.Duration).FirstOrDefault();
                var longestRunningSession = member.RunningSessions.OrderByDescending(m => m.Duration).FirstOrDefault();

                if (shortestCyclingSession != null && shortestRunningSession != null)
                {
                    sessionsStatistics.ShortestSession = shortestCyclingSession.Duration < shortestRunningSession.Duration ? shortestCyclingSession : shortestRunningSession;
                }
                if (longestCyclingSession != null && longestRunningSession != null)
                {
                    sessionsStatistics.LongestSession = longestCyclingSession.Duration > longestRunningSession.Duration ? longestCyclingSession : longestRunningSession;
                }
                if (shortestCyclingSession == null) sessionsStatistics.ShortestSession = shortestRunningSession;
                if (longestCyclingSession == null) sessionsStatistics.LongestSession = longestRunningSession;
                if (shortestRunningSession == null) sessionsStatistics.ShortestSession = shortestCyclingSession;
                if (longestRunningSession == null) sessionsStatistics.LongestSession = longestCyclingSession;

                sessionsStatistics.SessionCount = member.CyclingSessions.Count + member.RunningSessions.Count;
                int totalHourCount = 0;
                for (int i = 0; i < member.RunningSessions.Count; i++)
                {
                    totalHourCount += Convert.ToInt32(member.RunningSessions[i].Duration.TotalHours);
                }
                for (int i = 0; i < member.CyclingSessions.Count; i++)
                {
                    totalHourCount += Convert.ToInt32(member.CyclingSessions[i].Duration.TotalHours);
                }
                sessionsStatistics.TotalHourCount = totalHourCount;
                sessionsStatistics.AvgSessionTime = totalHourCount / (member.CyclingSessions.Count + member.RunningSessions.Count);
            }
            else
            {
                throw new Exception("This member doesn't have any sessions");
            }
            return sessionsStatistics;
        }
        [Route("CyclingSessionMonthly/{id}")]
        [HttpGet]
        public List<CyclingSessionMonthDTO> GetCyclingSessionMonthly(int id, int year)
        {
            Member member = RepoService.GetMember(id);
            List<CyclingSessionMonthDTO> cyclingSessionsListWithMonthList = new List<CyclingSessionMonthDTO>();
            if (member.CyclingSessions != null)
            {
                for (int i = 1; i < 13; i++)
                {
                    List<CyclingSessionDTO> cyclingSessionsList = new List<CyclingSessionDTO>();
                    CyclingSessionMonthDTO cyclingSessionListWithMonth = new CyclingSessionMonthDTO();
                    cyclingSessionListWithMonth.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                    for (int j = 0; j < member.CyclingSessions.Count; j++)
                    {
                        if (member.CyclingSessions[j].Date.Month == i && member.CyclingSessions[j].Date.Year == year)
                        {
                            CyclingSessionDTO cyclingSession = new CyclingSessionDTO
                            {
                                CyclingSessionId = member.CyclingSessions[j].CyclingSessionId,
                                AvgCadence = member.CyclingSessions[j].AvgCadence,
                                MaxCadence = member.CyclingSessions[j].MaxCadence,
                                AvgWatt = member.CyclingSessions[j].AvgWatt,
                                MaxWatt = member.CyclingSessions[j].MaxWatt,
                                Comment = member.CyclingSessions[j].Comment,
                                Date = member.CyclingSessions[j].Date,
                                Duration = member.CyclingSessions[j].Duration,
                                MemberId = member.CyclingSessions[j].MemberId,
                                TrainingType = member.CyclingSessions[j].TrainingType
                            };

                            TimeSpan timeSpan = new TimeSpan(1, 30, 0);
                            if (cyclingSession.AvgWatt < 150 && cyclingSession.Duration < timeSpan)
                            {
                                cyclingSession.Impact = "Low";
                            }
                            if (cyclingSession.AvgWatt < 150 && cyclingSession.Duration > timeSpan)
                            {
                                cyclingSession.Impact = "Medium";
                            }
                            if (cyclingSession.AvgWatt > 150 && cyclingSession.AvgWatt < 200)
                            {
                                cyclingSession.Impact = "Medium";
                            }
                            if (cyclingSession.AvgWatt > 200)
                            {
                                cyclingSession.Impact = "High";
                            }
                            cyclingSessionsList.Add(cyclingSession);
                        }
                    }
                    cyclingSessionListWithMonth.CyclingSessionDTO = cyclingSessionsList;
                    cyclingSessionsListWithMonthList.Add(cyclingSessionListWithMonth);
                }
                return cyclingSessionsListWithMonthList;
            }
            else
            {
                throw new Exception("This member doesn't have any cyclingSessions");
            }
        }
    }
}
