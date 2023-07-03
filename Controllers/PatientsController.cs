using HospitalManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementApp.Controllers
{
    public class PatientsController : Controller
    {   //3rd step
        //scaffolding is process of generating required files/codes/folders
        // GET: Patients
        //Action Mrthod
        public ViewResult GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            PatientModelManager modelManager = new PatientModelManager();
            DataSet dataSet = modelManager.GetPatients();
            foreach(DataRow dr in dataSet.Tables[0].Rows)
            {
                patients.Add(new Patient
                {
                    Pid = Convert.ToInt32(dr["pid"]),
                    Fname = dr["fname"].ToString(),
                    Lname = dr["lname"].ToString(),
                    Gender = dr["gender"].ToString(),
                    Age = Convert.ToInt32(dr["age"]),
                    Bg = dr["bg"].ToString(),
                    Desease = dr["desease"].ToString(),
                    Doctor_id = Convert.ToInt32(dr["doctor_id"])
                });
            }
            return View(patients);
        }
        [HttpGet]
        public ViewResult CreatePatient()
        {
            Patient patient = new Patient();
            return View(patient);
        }

        [HttpPost]
        public ActionResult CreatePatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                PatientModelManager modelManager = new PatientModelManager();
                int insertedRow = modelManager.CreatePatient(patient);

                if (insertedRow > 0)
                {
                    return RedirectToAction("GetAllPatients");
                }
            }
            return View(patient);
        }

        [HttpGet]
        public ActionResult UpdatePatient(int id)
        {
            PatientModelManager modelManager = new PatientModelManager();
            Patient patient = modelManager.GetPatientById(id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult UpdatePatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                PatientModelManager modelManager = new PatientModelManager();
                int updatedRow = modelManager.UpdatePatient(patient);
                if (updatedRow > 0)
                {
                    return RedirectToAction("GetAllPatients");
                }
            }
            return View(patient);
        }

        public ActionResult DeletePatient(int id)
        {
            PatientModelManager patientModelManager = new PatientModelManager();
            int deleteRow = patientModelManager.DeletePatient(id);
            if(deleteRow > 0)
            {
                return RedirectToAction("GetAllPatients");
            }
            return View();
        }
    }
}