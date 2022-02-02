using AutoMapper;
using EmployeeMgt.Core.ViewModels;
using EmployeeMgt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Employee, EmployeeProfileVM>().ReverseMap();
            CreateMap<Role, RoleVM>().ReverseMap();
            CreateMap<UserLogin, UserLoginVM>().ReverseMap();
            CreateMap<UserRole, UserRoleVM>().ReverseMap();
        }
    }
}
