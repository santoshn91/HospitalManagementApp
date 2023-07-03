using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalManagementApp.Models
{
    public class PatientModelManager// repository it will perform CRUD operations in DB
    {   // 2nd step
        //performs CRUD operations in DB
        //we need 4 methods here GetAllPatient(), CreatePatient(), UpdatePatient(), DeletePatient()
        string cn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public DataSet GetPatients()
        {
            //we are going to return all patient data from db
            using(SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getallpatient", con);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            //List<Patient> patients = new List<Patient>();
            //while (dataReader.Read())
            //{
            //    Patient patient = new Patient();
            //    patient.Pid = Convert.ToInt32(dataReader["pid"]);
            //    patient.Fname = dataReader["fname"].ToString();
            //    patient.Lname = dataReader["lname"].ToString();
            //    patient.Age = Convert.ToInt32(dataReader["age"]);
            //    patient.Bg = dataReader["bg"].ToString();
            //    patients.Add(patient);
            //}
            //connection.Close();
        }

        public int CreatePatient(Patient patient)
        {
            using(SqlConnection con=new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("insertpatient", con);
                command.Parameters.AddWithValue("fname", patient.Fname);
                command.Parameters.AddWithValue("lname", patient.Lname);
                command.Parameters.AddWithValue("gender", patient.Gender);
                command.Parameters.AddWithValue("age", patient.Age);
                command.Parameters.AddWithValue("bg", patient.Bg);
                command.Parameters.AddWithValue("desease", patient.Desease);
                command.Parameters.AddWithValue("doctor_id", patient.Doctor_id);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                int insertedRow = command.ExecuteNonQuery();
                con.Close();
                return insertedRow;
            }
            //SqlConnection connection = new SqlConnection("data source=SANTOSH_N; initial catalog=PalleTraining; integrated security=sspi");
            //string query = string.Format("insert into Patient values({0}, '{1}','{2}',{3},'{4}')", patient.Pid,patient.Fname,patient.Lname,patient.Age,patient.Bg);
            //SqlCommand command = new SqlCommand(query, connection);
            //connection.Open();
            //int insertedRows = command.ExecuteNonQuery();
            //connection.Close();
            //return insertedRows;
        }

        public Patient GetPatientById(int pid)
        {
            //we are going to return all patient data from db
            //SqlConnection connection = new SqlConnection("data source=SANTOSH_N; initial catalog=PalleTraining; integrated security=sspi");
            using(SqlConnection con=new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getpatientbyid", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("pid", pid);
                con.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                Patient patient = new Patient();
                if (dataReader.Read())
                {
                    patient.Pid = Convert.ToInt32(dataReader["pid"]);
                    patient.Fname = dataReader["fname"].ToString();
                    patient.Lname = dataReader["lname"].ToString();
                    patient.Gender = dataReader["gender"].ToString();
                    patient.Age = Convert.ToInt32(dataReader["age"]);
                    patient.Bg = dataReader["bg"].ToString();
                    patient.Desease = dataReader["desease"].ToString();
                    patient.Doctor_id = Convert.ToInt32(dataReader["doctor_id"]);
                }
                con.Close();
                return patient;
            }
        }

        public int UpdatePatient(Patient patient)
        {
            using(SqlConnection con=new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("updatepatient", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("pid", patient.Pid);
                command.Parameters.AddWithValue("fname", patient.Fname);
                command.Parameters.AddWithValue("lname", patient.Lname);
                command.Parameters.AddWithValue("gender", patient.Gender);
                command.Parameters.AddWithValue("age", patient.Age);
                command.Parameters.AddWithValue("bg", patient.Bg);
                command.Parameters.AddWithValue("desease", patient.Desease);
                command.Parameters.AddWithValue("doctor_id", patient.Doctor_id);
                con.Open();
                int updatedRows = command.ExecuteNonQuery();
                con.Close();
                return updatedRows;
            }
        }

        public List<Gender> GetGender()
        {
            using(SqlConnection con= new SqlConnection(cn))
            {
                SqlCommand cmd = new SqlCommand("getgender", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Gender> genders = new List<Gender>();
                while (reader.Read())
                {
                    Gender gender = new Gender();
                    gender.Id = Convert.ToInt32(reader["id"]);
                    gender.Name = reader["name"].ToString();
                    genders.Add(gender);
                }
                con.Close();
                return genders;
            }
        }

        public List<Bg> GetBg()
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getbg", con);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Bg> bgs = new List<Bg>();
                while (reader.Read())
                {
                    Bg bg = new Bg();
                    bg.Bid = Convert.ToInt32(reader["bid"]);
                    bg.Bgname = reader["bgname"].ToString();
                    bgs.Add(bg);
                }
                con.Close();
                return bgs;
            }
        }

        public List<Doctor> GetDoctor()
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("getdoctor", con);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Doctor> doctors = new List<Doctor>();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.Did = Convert.ToInt32(reader["did"]);
                    doctor.Fname = reader["fname"].ToString();
                    doctors.Add(doctor);
                }
                con.Close();
                return doctors;
            }
        }

        public int DeletePatient(int id)
        {
            using(SqlConnection con=new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("deletepatientbyid1", con);
                command.Parameters.AddWithValue("pid", id);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                int deletedRow = command.ExecuteNonQuery();
                con.Close();
                return deletedRow;
            }
        }
    }
}