using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO _instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(_instance == null)
                    {
                        _instance = new MemberDAO();
                    }
                    return _instance;
                }
            }
        }

        public Member GetMemberLogin(String email, String password)
        {
            Member member = null;
            try
            {
                var db = new FStoreDBAssignmentContext();
                member = db.Members.SingleOrDefault(mem => mem.Email == email 
                                     && mem.Password == password);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public IEnumerable<Member> GetMemberList()
        {
            List<Member> members;
            try
            {
                var db = new FStoreDBAssignmentContext();
                members = db.Members.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberById(int id)
        {
            Member member = null;
            try
            {
                var db = new FStoreDBAssignmentContext();
                member = db.Members.SingleOrDefault(mem => mem.MemberId == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void Create(Member member)
        {
            try
            {
                var mem = GetMemberById(member.MemberId);
                if(mem == null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Members.Add(member);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This member already exists.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Member member)
        {
            try
            {
                var mem = GetMemberById(member.MemberId);
                if(mem != null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Entry<Member>(member).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This member doesn't exist");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Member member)
        {
            try
            {
                var mem = GetMemberById(member.MemberId);
                if (mem != null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Members.Remove(member);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This member doesn't exist");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
