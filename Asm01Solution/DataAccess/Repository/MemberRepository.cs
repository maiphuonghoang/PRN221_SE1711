using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member member) => MemberDAO.Instance.AddMember(member);

        public void DeleteMember(Member member) => MemberDAO.Instance.DeleteMember(member);

        public IEnumerable<Member> GetAllMembers() => MemberDAO.Instance.GetAllMembers();  

        public Member GetMemberByEmail(string email, string password) => MemberDAO.Instance.getMemberByEmail(email, password);

        public Member GetMemberById(int id) => MemberDAO.Instance.getMemberById(id);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}
