using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymTestBL.Models;
using GymTestBL.Interfaces;
using GymTestDL.Mappers;
using GymTestDL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace GymTestDL.Repositories
{
    public class MemberRepositoryEF : IMemberRepository
    {
        private GymTestContext _context;
        public MemberRepositoryEF(GymTestContext context)
        {
            _context = context;
        }
        private void SaveAndClear()
        {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        public Member GetMember(int id)
        {
            try
            {
                var member = _context.Members
                    .Include(m => m.Programs)
                    .Include(m => m.Reservations)
                    .Include(m => m.CyclingSessions)
                    .Include(m => m.RunningSessions)
                    .FirstOrDefault(m => m.MemberId == id);

                return member != null ? MapMember.MapToBL(member) : throw new Exception("Member is null");
            }
            catch (Exception ex)
            {
                throw new Exception("GetMember", ex);
            }
        }
        public List<Member> GetAllMembers()
        {
            try
            {
                return _context.Members
                    .Include(m => m.Programs)
                    .Include(m => m.Reservations)
                    .Include(m => m.CyclingSessions)
                    .Include(m => m.RunningSessions)
                    .Select(m => MapMember.MapToBL(m))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllMembers",ex);
            }
        }
        public Member UpdateMember(Member member) 
        {
            try
            {
                var memberDB = _context.Members.Find(member.MemberId);

                if (memberDB == null) { throw new Exception("UpdateMember - Member not found");}

                _context.Entry(memberDB).CurrentValues.SetValues(MapMember.MapToDL(member));
                _context.SaveChanges();
                return MapMember.MapToBL(memberDB);
            }
            catch (Exception ex)
            {

                throw new Exception("UpdateMember",ex);
            }
        }
        public bool DeleteMember(int id)
        {
            try
            {
                _context.Members.Remove(new MemberEF() { MemberId = id });
                SaveAndClear();
                return true;
            }
            catch (Exception)
            {

                throw new Exception("DeleteMember");
            }
        }
        public Member AddMember(Member member)
        {
            try
            {
                var memberDB = MapMember.MapToDL(member);
                _context.Members.Add(memberDB);
                _context.SaveChanges();
                return MapMember.MapToBL(memberDB);

            }
            catch (Exception ex)
            {
                throw new Exception("AddMember",ex);
            }
        }
    }
}
