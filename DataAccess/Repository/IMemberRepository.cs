using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMember();
        Member GetMemberByID(int carId);
        void InsertMember(Member member);
        void DeleteMember(int memberId);
        void UpdateMember(Member member);
        Member Login(string email, string password);
    }
}
