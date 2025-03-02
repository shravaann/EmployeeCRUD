using Microsoft.Data.SqlClient;
using EmployeeCRUD.Models;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore.SqlServer.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeCRUD.DAL

{


    public class Employee_DAL

    {
        SqlConnection connection = null;
        SqlCommand command = null;
        private SqlConnection _connection;
        private SqlCommand _command;

        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory
                ()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");


        }

        public List<EmployeeForm> GetAll()
        {
            List<EmployeeForm> EmployeeList = new List<EmployeeForm>();
            using (_connection = new SqlConnection(GetConnectionString()))

            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[getNewtbl_Employee]";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read()) 
                
                {
                    EmployeeForm employee = new EmployeeForm();
                    employee.Id = Convert.ToInt32(dr["ID"]);
                    employee.EmployeeCode = Convert.ToInt32(dr["EmployeeCode"]);
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.DateofBirth = Convert.ToDateTime(dr["DateofBirth"]).Date;
                    employee.DateofJoining = Convert.ToDateTime(dr["DateofJoining"]).Date;
                    employee.EmailAddress = dr["EmailAddress"].ToString();
                    employee.PhoneNumber = dr["PhoneNumber"].ToString();
                    employee.Gender = dr["Gender"].ToString();
                    EmployeeList.Add(employee);




                }
                _connection.Close();
            }
            return EmployeeList;
        }

           public bool Insert(EmployeeForm model)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString())) 
            
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[insertNewtbl_Employee]";
                _command.Parameters.AddWithValue("@EmployeeCode", model.EmployeeCode);
                _command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                _command.Parameters.AddWithValue("@DateofBirth", model.DateofBirth);
                _command.Parameters.AddWithValue("@DateofJoining", model.DateofJoining);
                _command.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                _command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                _command.Parameters.AddWithValue("@Gender", model.Gender);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();


            }
            return id > 0 ? true : false;

        }

        public EmployeeForm GetById(int id)
        {
            EmployeeForm employee = new EmployeeForm();
            using (_connection = new SqlConnection(GetConnectionString()))

            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[getNewtbl_EmployeeById]";
                _command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())

                {
                    employee.Id = Convert.ToInt32(dr["ID"]);
                    employee.EmployeeCode = Convert.ToInt32(dr["EmployeeCode"]);
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.DateofBirth = Convert.ToDateTime(dr["DateofBirth"]).Date;
                    employee.DateofJoining = Convert.ToDateTime(dr["DateofJoining"]).Date;
                    employee.EmailAddress = dr["EmailAddress"].ToString();
                    employee.PhoneNumber = dr["PhoneNumber"].ToString();
                    employee.Gender = dr["Gender"].ToString();  

                }
                _connection.Close();
            }
            return employee;
        }

        public bool Update(EmployeeForm model)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString()))

            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[updateNewtbl_Employee]";
                _command.Parameters.AddWithValue("@Id", model.Id);
                _command.Parameters.AddWithValue("@EmployeeCode", model.EmployeeCode);
                _command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                _command.Parameters.AddWithValue("@DateofBirth", model.DateofBirth);
                _command.Parameters.AddWithValue("@DateofJoining", model.DateofJoining);
                _command.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                _command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                _command.Parameters.AddWithValue("@Gender", model.Gender);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();


            }
            return id > 0 ? true : false;

        }
        public bool Delete(int id)
        {
            int deletedRowCount = 0;
            using (_connection = new SqlConnection(GetConnectionString()))

            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[deleteNewtbl_Employee]";
                _command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                deletedRowCount = _command.ExecuteNonQuery();
                _connection.Close();


            }
            return deletedRowCount > 0 ? true : false;

        }


    }
}














