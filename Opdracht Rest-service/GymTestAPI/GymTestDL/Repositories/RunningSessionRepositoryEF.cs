using GymTestBL.Interfaces;
using GymTestBL.Models;
using GymTestDL.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Repositories
{
    public class RunningSessionRepositoryEF : IRunningSessionRepository
    {
        private GymTestContext _context;
        public RunningSessionRepositoryEF(GymTestContext context)
        {
            _context = context;
        }
     
        public RunningSessionMain GetRunningSession(int id)
        {
            try
            {
                var session = _context.RunningSessionMains
                    .Include(s => s.Details)
                    .FirstOrDefault(s => s.RunningSessionId == id);

                return session != null ? RunningSessionMapper.MapToBL(session) : throw new Exception("session is null");
            }
            catch (Exception ex)
            {
                throw new Exception("GetRunningSession", ex);
            }
        }
    }
}
