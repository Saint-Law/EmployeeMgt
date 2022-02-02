using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.ViewModels
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Next of Kin Name")]
        public string KinName { get; set; }
        [Display(Name = "Kin Address")]
        public string KinAddress { get; set; }
        [Display(Name = "Kin Mobile")]
        public string KinMobile { get; set; }
        [Display(Name = "Guarantor Name")]
        public string GuarantorName1 { get; set; }
        [Display(Name = "Guarantor Address")]
        public string GuarantorAddress1 { get; set; }
        [Display(Name = "Guarantor Phone")]
        public string GuarantorPhone1 { get; set; }
        [Display(Name = "Guarantor Name 2")]
        public string GuarantorName2 { get; set; }
        [Display(Name = "Guarantor Address 2")]
        public string GuarantorAddress2 { get; set; }
        [Display(Name = "Guarantor Phone 2")]
        public string GuarantorPhone2 { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }

    public class EmployeeProfileVM
    {
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Next of Kin Name")]
        public string KinName { get; set; }
        [Display(Name = "Kin Address")]
        public string KinAddress { get; set; }
        [Display(Name = "Kin Mobile")]
        public string KinMobile { get; set; }
        [Display(Name = "Guarantor Name")]
        public string GuarantorName1 { get; set; }
        [Display(Name = "Guarantor Address")]
        public string GuarantorAddress1 { get; set; }
        [Display(Name = "Guarantor Phone")]
        public string GuarantorPhone1 { get; set; }
        [Display(Name = "Guarantor Name 2")]
        public string GuarantorName2 { get; set; }
        [Display(Name = "Guarantor Address 2")]
        public string GuarantorAddress2 { get; set; }
        [Display(Name = "Guarantor Phone 2")]
        public string GuarantorPhone2 { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
