using HospitalManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementApp.Controllers
{
    public class DoctorsController : Controller
    {
        // GET: Doctors
        public ViewResult GetDoctors()
        {
            DoctorModelManager doctorModelManager = new DoctorModelManager();
            DataSet dataSet = doctorModelManager.GetDoctors();
            List<Doctor> doctors = new List<Doctor>();
            foreach(DataRow item in dataSet.Tables[0].Rows)
            {
                doctors.Add(new Doctor
                {
                    Did = Convert.ToInt32(item["did"]),
                    Fname = item["fname"].ToString(),
                    Lname = item["lname"].ToString(),
                    Gender = item["gender"].ToString(),
                    Age = Convert.ToInt32(item["age"]),
                    Dept = item["dept"].ToString()
                });
            }
            return View(doctors);
        }

        [HttpGet]
        public ViewResult CreateDoctor()
        {
            Doctor doctor = new Doctor();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                DoctorModelManager doctorModelManager = new DoctorModelManager();
                int insertedRow = doctorModelManager.CreateDoctor(doctor);
                if (insertedRow > 0)
                {
                    return RedirectToAction("GetDoctors");
                }
            }
            return View(doctor);
        }

        [HttpPost]
        public ActionResult UpdateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                DoctorModelManager doctorModelManager = new DoctorModelManager();
                int updatedRow = doctorModelManager.UpdateDoctor(doctor);
                if (updatedRow > 0)
                {
                    return RedirectToAction("GetDoctors");
                }
            }
            return View(doctor);
        }

        [HttpGet]
        public ViewResult updateDoctor(int id)
        {
            DoctorModelManager doctorModelManager = new DoctorModelManager();
            Doctor doctor = doctorModelManager.GetDoctorbyid(id);
            return View(doctor);
        }

        public ActionResult DeleteDoctor(int id)
        {
            DoctorModelManager doctorModelManager = new DoctorModelManager();
            int deletedRow = doctorModelManager.DeleteDoctor(id);
            if(deletedRow > 0)
            {
                return RedirectToAction("GetDoctors");
            }
            return View();
        }

        public ActionResult DoctorDetails(int id)
        {
            DoctorModelManager doctorModelManager = new DoctorModelManager();
            DataSet dataSet = doctorModelManager.GetDoctorDetails(id);
            List<Patient> patients = new List<Patient>();
            Doctor doctor = new Doctor();
            foreach(DataRow item in dataSet.Tables[0].Rows)
            {
                patients.Add(new Patient
                {
                    Pid = Convert.ToInt32(item["pid"]),
                    Fname = item["fname"].ToString(),
                    Lname = item["lname"].ToString(),
                    Gender = item["gender"].ToString(),
                    Age = Convert.ToInt32(item["age"]),
                    Bg = item["bg"].ToString(),
                    Desease = item["desease"].ToString(),
                    Doctor_id = Convert.ToInt32(item["doctor_id"])
                });
            }
            return View(patients);
        }
    }
}