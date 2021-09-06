using EmployeeAPI.Interface;
using EmployeeAPI.Models;
using EmployeeAPI.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAPI.Concrete
{
    public class EmployeeMasterConcrete : IEmployeeMaster
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        public EmployeeMasterConcrete(DatabaseContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public bool AddEmployee(EmployeeMasterVM obj)
        {
            _context.EmployeeMasters.Add(new EmployeeMaster
            {
                Id = obj.Id,
                FirstName = obj.FirstName,
                MiddleName = obj.MiddleName,
                LastName = obj.LastName
            });
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateEmployee(EmployeeMasterVM obj)
        {
            var empData = (from data in _context.EmployeeMasters
                           where data.Id == obj.Id
                           select data).FirstOrDefault();

            if (empData.Id > 0)
            {
                empData.FirstName = obj.FirstName;
                empData.LastName = obj.LastName;
                empData.MiddleName = obj.MiddleName;
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool RemoveEmployee(int id)
        {
            var empData = (from data in _context.EmployeeMasters
                           where data.Id == id
                           select data).FirstOrDefault();
            if (empData != null)
            {
                _context.EmployeeMasters.Remove(empData);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<EmployeeMasterVM> GetEmployee()
        {
            var result = (from dt in _context.EmployeeMasters
                          select new EmployeeMasterVM()
                          {
                              Id = dt.Id,
                              FirstName = dt.FirstName,
                              MiddleName = dt.MiddleName,
                              LastName = dt.LastName
                          }).ToList();

            return result;
        }
    }
}