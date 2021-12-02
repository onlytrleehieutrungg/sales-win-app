using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using BusinessObject;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class MemberDBContext : BaseDal
    {
        private static MemberDBContext instance = null;
        private static readonly object instanceLock = new object();
        private MemberDBContext()
        {
           
        }
        public static MemberDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDBContext();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetMemberList()
        {
            IDataReader dataReader = null;
            String SQLSelect = "Select MemberId, Email, CompanyName, City, Country, Password from Member";
            Member DefaultAdmin = GetDefaultMember();
            var members = new List<Member>();
            if (DefaultAdmin != null)
            {
                members.Add(DefaultAdmin);
            }
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {   
                    members.Add(new Member
                    {
                        MemberId = dataReader.GetInt32(0),
                        Email = dataReader.GetString(1),
                        CompanyName = dataReader.GetString(2),
                        City = dataReader.GetString(3),
                        Country = dataReader.GetString(4),
                        Password = dataReader.GetString(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return members;
        }

        public Member GetMemberByID(int memberId)
        {
            Member member = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select MemberId, Email, CompanyName, City, Country, Password " +
                            " from Member where MemberId = @MemberId";
            try
            {
                var param = dataProvider.CreateParameter("@MemberId", 4, memberId, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection,param);
                if (dataReader.Read())
                {
                    member = new Member
                    {
                        MemberId = dataReader.GetInt32(0),
                        Email = dataReader.GetString(1),
                        CompanyName = dataReader.GetString(2),
                        City = dataReader.GetString(3),
                        Country = dataReader.GetString(4),
                        Password = dataReader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return member;
        }

        public void AddNew(Member member)
        {
            try
            {
                Member pro = GetMemberByID(member.MemberId);
                if (pro == null)
                {
                    string SQLInsert = "Insert Member values(@MemberId,@Email,@CompanyName,@City,@Country,@Password)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, member.MemberId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@Email", 50, member.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@CompanyName", 50, member.CompanyName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, member.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, member.Country, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, member.Password, DbType.String));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        public void Update(Member member)
        {
            try
            {
                Member pro = GetMemberByID(member.MemberId);
                if (pro != null)
                {
                    string SQLInsert = "Update Member set Email = @Email, CompanyName = @CompanyName,"
                        + "City = @City,Country= @Country,Password = @Password Where MemberId = @MemberId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, member.MemberId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@Email", 50, member.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, member.Password, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@CompanyName", 50, member.CompanyName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, member.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, member.Country, DbType.String));
                    
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int carID)
        {


            try
            {
                Member member = GetMemberByID(carID);
                if (member != null)
                {
                    String SQLDelete = "Delete Member Where MemberId = @MemberId";
                    var param = dataProvider.CreateParameter("@MemberId", 4, carID, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);

                }
                else
                {
                    throw new Exception("The Member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

        

        private Member GetDefaultMember()
        {
            Member Default = null;
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
                string email = config["account:defaultAccount:email"];
                string password = config["account:defaultAccount:password"];
                Default = new Member
                {
                    MemberId = 0,
                    Email = email,
                    Password = password,
                    City = "",
                    Country = "",
                    CompanyName = ""
                };
            }

            return Default;
        }


        public Member Login(string email, string password)
        {
            IEnumerable<Member> members = GetMemberList();
            Member member = members.SingleOrDefault(mb => mb.Email.Equals(email) && mb.Password.Equals(password));
            return member;
        }

        public IEnumerable<Member> SearchMember(int id)
        {
            IEnumerable<Member> searchResult = null;
            IEnumerable<Member> members = GetMemberList();

            var memberSearch = from member in members
                               where member.MemberId == id
                               select member;
            searchResult = memberSearch;

            return searchResult;
        }


    



    }
}
