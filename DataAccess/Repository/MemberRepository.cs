using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int memberId) => MemberDBContext.Instance.Remove(memberId);
       

        public Member GetMemberByID(int memberId) => MemberDBContext.Instance.GetMemberByID(memberId);


        public IEnumerable<Member> GetMember() => MemberDBContext.Instance.GetMemberList();


        public void InsertMember(Member member) => MemberDBContext.Instance.AddNew(member);


        public void UpdateMember(Member member) => MemberDBContext.Instance.Update(member);

        public Member Login(string email, string password) => MemberDBContext.Instance.Login(email,password);

    }
}
