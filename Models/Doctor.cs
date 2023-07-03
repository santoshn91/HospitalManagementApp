using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementApp.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public int Did { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name must not be empty.")]
        public string Fname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name must not be empty.")]
        public string Lname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender must not be selected.")]
        public string Gender { get; set; }
        [Range(18, 80, ErrorMessage ="Age must between 18 to 80")]
        public int Age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender must not be selected.")]
        public string Dept { get; set; }

        public List<Gender> Genders
        {
            get
            {
                DoctorModelManager doctorModelManager = new DoctorModelManager();
                List<Gender> genders = doctorModelManager.GetGenders();
                return genders;
            }
        }

        public IEnumerable<SelectListItem> Depts
        {
            get
            {
                DoctorModelManager doctorModelManager = new DoctorModelManager();
                List<Depts> depts = doctorModelManager.GetDepts();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach(var item in depts)
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Text = item.Name;
                    selectListItem.Value = item.Name;
                    selectListItem.Selected = item.Name == "General" ? true : false;
                    selectListItems.Add(selectListItem);
                }
                return selectListItems;
            }
        }
    }
}