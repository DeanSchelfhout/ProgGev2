using GymTestBL.Interfaces;
using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Services
{
    public class MemberService
    {
        private IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            this._memberRepository = memberRepository;
        }
        public Member GetMember(int id)
        {
            try
            {
                return _memberRepository.GetMember(id);
            }
            catch (Exception)
            {

                throw new Exception("GetMember");
            }
        }
        public void DeleteMember(int id)
        {
            try
            {
                _memberRepository.DeleteMember(id);
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
                if (member == null) throw new Exception("AddMember - member is null");
                _memberRepository.AddMember(member);
                return member;
            }
            catch (Exception)
            {

                throw new Exception("AddMember");
            }
        }
        public List<Member> GetAllMembers()
        {
            try
            {
                return _memberRepository.GetAllMembers();
            }
            catch (Exception)
            {

                throw new Exception("GetAllMembers");
            }
        }
        public Member UpdateMember(Member member)
        {
            try
            {
                if (member == null) throw new Exception("UpdateMember - member is null");
                _memberRepository.UpdateMember(member);
                return member;
            }
            catch (Exception)
            {

                throw new Exception("UpdateMember");
            }
        }
    }
}
