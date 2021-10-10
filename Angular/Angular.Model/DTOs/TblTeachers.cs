using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblTeachers
    {

        public int Id { get; set; }
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherGender { get; set; }
        public string TeacherImage { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public List<TblClasses> TblClasses { get; set; }
        public List<TblSchedules> TblSchedules { get; set; }
    }
}
