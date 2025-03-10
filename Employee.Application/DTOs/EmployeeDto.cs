﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string documentoNumber { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public int PositionId { get; set; }
        public string Afp { get; set; }
        public int AfpId { get; set; }
    }
}
