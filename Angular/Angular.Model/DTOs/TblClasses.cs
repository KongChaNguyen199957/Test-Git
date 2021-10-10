using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblClasses
    {
        public int Id { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public int? DepartmentId { get; set; }
        public int? TeacherId { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public  TblDepartments Department { get; set; }
        public  TblTeachers Teacher { get; set; }
        public  List<TblSchedules> TblSchedules { get; set; }
        public List<TblStudents> TblStudents { get; set; }
    }
}
