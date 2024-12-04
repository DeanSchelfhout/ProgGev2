using GymTestBL.Interfaces;
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
    }
}
