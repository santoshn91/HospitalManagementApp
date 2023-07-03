using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalManagementApp.Models
{
    public class DoctorModelManager
    {
        string cn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public DataSet GetDoctors()
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getdoctors", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
        }

        public int CreateDoctor(Doctor doctor)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("createdoctor", con);
                command.Parameters.AddWithValue("fname", doctor.Fname);
                command.Parameters.AddWithValue("lname", doctor.Lname);
                command.Parameters.AddWithValue("gender", doctor.Gender);
                command.Parameters.AddWithValue("age", doctor.Age);
                command.Parameters.AddWithValue("dept", doctor.Dept);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                int insertedRow = command.ExecuteNonQuery();
                return insertedRow;
            }
        }

        public List<Gender> GetGenders()
        {
            using(SqlConnection con =new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getgender", con);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Gender> genders = new List<Gender>();
                while (reader.Read())
                {
                    Gender gender = new Gender();
                    gender.Id = Convert.ToInt32(reader["id"]);
                    gender.Name = reader["name"].ToString();
                    genders.Add(gender);
                }
                return genders;
            }
        }

        public List<Depts> GetDepts()
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getdepts", con);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Depts> depts = new List<Depts>();
                while (reader.Read())
                {
                    Depts dept = new Depts();
                    dept.Id = Convert.ToInt32(reader["id"]);
                    dept.Name = reader["name"].ToString();
                    depts.Add(dept);
                }
                return depts;
            }
        }

        public int UpdateDoctor(Doctor doctor)
        {
            using(SqlConnection con=new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("updatedoctor", con);
                command.Parameters.AddWithValue("did", doctor.Did);
                command.Parameters.AddWithValue("fname", doctor.Fname);
                command.Parameters.AddWithValue("lname", doctor.Lname);
                command.Parameters.AddWithValue("gender", doctor.Gender);
                command.Parameters.AddWithValue("age", doctor.Age);
                command.Parameters.AddWithValue("dept", doctor.Dept);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                int updatedRow = command.ExecuteNonQuery();
                return updatedRow;
            }
        }

        public Doctor GetDoctorbyid(int id)
        {
            using(SqlConnection con=new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getdoctorbyid", con);
                command.Parameters.AddWithValue("did", id);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                Doctor doctor = new Doctor();
                if (reader.Read())
                {
                    doctor.Did = Convert.ToInt32(reader["did"]);
                    doctor.Fname = reader["fname"].ToString();
                    doctor.Lname = reader["lname"].ToString();
                    doctor.Gender = reader["gender"].ToString();
                    doctor.Age = Convert.ToInt32(reader["age"]);
                    doctor.Dept = reader["dept"].ToString();
                }
                return doctor;
            }
        }

        public int DeleteDoctor(int id)
        {
            using(SqlConnection con =new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("delectdoctor", con);
                command.Parameters.AddWithValue("did", id);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                int deletedRow = command.ExecuteNonQuery();
                return deletedRow;
            }
        }

        public DataSet GetDoctorDetails(int id)
        {
            using(SqlConnection con=new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getdoctordetails", con);
                command.Parameters.AddWithValue("did", id);
                command.CommandType = CommandType.StoredProcedure;
                //SqlDataReader reader = command.ExecuteReader();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
        }
    }
}