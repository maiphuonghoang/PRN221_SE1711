using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
        void AddMember (Member member);
        void DeleteMember (Member member);
        void UpdateMember (Member member);
        Member GetMemberById (int id);
        Member GetMemberByEmail (string email, string password);

    }
}
