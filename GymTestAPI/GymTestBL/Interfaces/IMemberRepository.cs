using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymTestBL.Models;

namespace GymTestBL.Interfaces
{
    public interface IMemberRepository
    {
        Member GetMember(int Id);
        void DeleteMember(int Id);
        void UpdateMember(Member member);
        void AddMember(Member member);
        List<Member> GetAllMembers();
    }
}
