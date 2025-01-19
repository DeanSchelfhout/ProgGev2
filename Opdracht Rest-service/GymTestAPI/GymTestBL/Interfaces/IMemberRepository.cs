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
        bool DeleteMember(int Id);
        Member UpdateMember(Member member);
        Member AddMember(Member member);
        List<Member> GetAllMembers();
    }
}
