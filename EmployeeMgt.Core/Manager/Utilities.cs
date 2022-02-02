using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.Manager
{
    public class Utilities
    {
        public static string RESPONSECODE00 = "00";
        public static string RESPONSEMESSAGE00 = "Success";

        public static string RESPONSECODE01 = "01";
        public static string RESPONSEMESSAGE01 = "Failed";

        public static string RESPONSECODE50 = "50";
        public static string RESPONSEMESSAGE50 = "No Record found";


        public static string RESPONSECODE52 = "52";
        public static string RESPONSEMESSAGE52 = "Sorry, Record could not be Uploaded, pls try again";


        public static string RESPONSECODE53 = "53";
        public static string RESPONSEMESSAGE53 = "End date must be greater than start date";


        public static string RESPONSECODE90 = "90";
        public static string RESPONSEMESSAGE90 = "Oooops Something went wrong!";

        public static string RESPONSECODE99 = "99";
        public static string RESPONSEMESSAGE99 = "Request Processing Error";
    }
}
