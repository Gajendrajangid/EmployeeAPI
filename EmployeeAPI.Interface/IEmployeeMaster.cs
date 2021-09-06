using EmployeeAPI.Models;
using EmployeeAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace EmployeeAPI.Interface
{
    public interface IEmployeeMaster
    {
        List<EmployeeMasterVM> GetEmployee();
        bool AddEmployee(EmployeeMasterVM obj);
        bool UpdateEmployee(EmployeeMasterVM obj);
        bool RemoveEmployee(int Id);
    }
}
