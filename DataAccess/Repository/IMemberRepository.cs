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
        IEnumerable<MemberObject> GetMemberList();
        MemberObject GetMemberById(int id);
        bool LoginAdmin(String email, String password);
        MemberObject LoginMember(String email, String password);
        void CreateMember(MemberObject memberObject);
        void UpdateMember(MemberObject memberObject);
        void DeleteMember(MemberObject memberObject);
    }
}
