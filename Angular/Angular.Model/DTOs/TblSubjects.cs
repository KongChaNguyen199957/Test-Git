using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblSubjects
    {
        public int Id { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int? NumberOfPeriod { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public List<TblSchedules> TblSchedules { get; set; }
        public List<TblStudentSubject> TblStudentSubject { get; set; }
    }
}
