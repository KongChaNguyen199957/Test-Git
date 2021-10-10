using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblStudents
    {

        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public string StudentGender { get; set; }
        public string StudentImage { get; set; }
        public int? ClassId { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public TblClasses Class { get; set; }
        public List<TblAttendances> TblAttendances { get; set; }
        public List<TblStudentSubject> TblStudentSubject { get; set; }
    }
}
