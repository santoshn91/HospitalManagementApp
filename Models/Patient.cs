using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementApp.Models
{   // 1st Step
    [Table("Patient Details.")]
    public class Patient
    {
        [Key]
        public int Pid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name must not be empty...")]
        public string Fname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name must not be empty...")]
        public string Lname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage ="Gender Must be selected...")]
        public string Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Age must not be empty...")]
        public int Age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Blood Group Must be selected...")]
        public string Bg { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Desease Must be selected...")]
        public string Desease { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Doctor Must be selected...")]
        public int Doctor_id { get; set; }

        public List<Gender> Genders
        {
            get
            {
                PatientModelManager patientModelManager = new PatientModelManager();
                List<Gender> genders = patientModelManager.GetGender();
                return genders;
            }
        }

        public IEnumerable<SelectListItem> Bgs
        {
            get
            {
                PatientModelManager patientModelManager = new PatientModelManager();
                List<Bg> bgs = patientModelManager.GetBg();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (var item in bgs)
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Text = item.Bgname;
                    selectListItem.Value = item.Bgname;
                    selectListItem.Selected = item.Bgname == "a+ve" ? true : false;
                    selectListItems.Add(selectListItem);
                }
                return selectListItems;
            }
        }

        public IEnumerable<SelectListItem> Doctors
        {
            get
            {
                PatientModelManager patientModelManager = new PatientModelManager();
                List<Doctor> doctors = patientModelManager.GetDoctor();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach(var item in doctors)
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Text = item.Fname;
                    selectListItem.Value = item.Did.ToString();
                    selectListItem.Selected = item.Fname == "Deshapande" ? true : false;
                    selectListItems.Add(selectListItem);
                }
                return selectListItems;
            }
        }
    }
}