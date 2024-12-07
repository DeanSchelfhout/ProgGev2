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
            catch (Exception ex)
            {

                throw new Exception("GetMember",ex);
            }
        }
        public bool DeleteMember(int id)
        {
            try
            {
               _memberRepository.DeleteMember(id);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteMember",ex);
            }
        }
        public Member AddMember(Member member)
        {
            try
            {
                if (member == null) throw new Exception("AddMember - member is null");
                return _memberRepository.AddMember(member);
            }
            catch (Exception ex)
            {

                throw new Exception("AddMember",ex);
            }
        }
        public List<Member> GetAllMembers()
        {
            try
            {
                return _memberRepository.GetAllMembers();
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
                if (member == null) throw new Exception("UpdateMember - member is null");
                _memberRepository.UpdateMember(member);
                return member;
            }
            catch (Exception ex)
            {

                throw new Exception("UpdateMember",ex);
            }
        }
    }
}
