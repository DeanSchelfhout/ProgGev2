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
                return MapMember.MapToBL((MemberEF)_context.Members.Where(m => m.MemberId == id));
            }
            catch (Exception)
            {

                throw new Exception("GetMember");
            }
        }
        public List<Member> GetAllMembers()
        {
            try
            {
                return _context.Members.Select(m => MapMember.MapToBL(m)).ToList();
            }
            catch (Exception)
            {

                throw new Exception("GetMembers");
            }
        }
        public void UpdateMember(Member member) 
        {
            try
            {
                _context.Members.Update(MapMember.MapToDL(member));
            }
            catch (Exception)
            {

                throw new Exception("UpdateMember");
            }
        }
        public void DeleteMember(int id)
        {
            try
            {
                _context.Members.Remove(new MemberEF() { MemberId = id });
                SaveAndClear();
            }
            catch (Exception)
            {

                throw new Exception("DeleteMember");
            }
        }
        public void AddMember(Member member)
        {
            try
            {
                _context.Members.Add(MapMember.MapToDL(member));
            }
            catch (Exception)
            {

                throw new Exception("AddMember");
            }
        }
    }
}
