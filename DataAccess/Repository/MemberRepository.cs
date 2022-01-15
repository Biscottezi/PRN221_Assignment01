using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoMapper;
using BusinessObject;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private IMapper mapper;
        public MemberRepository()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Member, MemberObject>().ReverseMap();
                mc.CreateMap<Product, ProductObject>().ReverseMap();
                mc.CreateMap<Order, OrderObject>().ReverseMap();
                mc.CreateMap<OrderDetail, OrderDetailObject>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public IEnumerable<MemberObject> GetMemberList()
        {
            try
            {
                var members = MemberDAO.Instance.GetMemberList();
                var memberList = mapper.Map<IEnumerable<Member>, IEnumerable<MemberObject>>(members);
                return memberList;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MemberObject GetMemberById(int id)
        {
            try
            {
                var mem = MemberDAO.Instance.GetMemberById(id);
                var member = mapper.Map<Member, MemberObject>(mem);
                return member;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool LoginAdmin(String email, String password)
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
            String adminEmail = config["admin:email"];
            String adminPassword = config["admin:password"];
            if(email == adminEmail && password == adminPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MemberObject LoginMember(String email, String password)
        {
            try
            {
                var mem = MemberDAO.Instance.GetMemberLogin(email, password);
                var member = mapper.Map<Member, MemberObject>(mem);
                return member;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateMember(MemberObject memberObject)
        {
            try
            {
                var member = mapper.Map<MemberObject, Member>(memberObject);
                MemberDAO.Instance.Create(member);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(MemberObject memberObject)
        {
            try
            {
                var member = mapper.Map<MemberObject, Member>(memberObject);
                MemberDAO.Instance.Update(member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteMember(MemberObject memberObject)
        {
            try
            {
                var member = mapper.Map<MemberObject, Member>(memberObject);
                MemberDAO.Instance.Delete(member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
