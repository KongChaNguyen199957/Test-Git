using System;
using System.Collections.Generic;
using System.Text;

namespace Angular.Model.DTOs
{
    public class TblStudentSubject
    {
        public int StudentSubjectCode { get; set; }
        public int? SubjectId { get; set; }
        public int? StudentId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? OrderNumber { get; set; }


        public TblSubjects Subjects { get; set; }
        public TblStudents Students { get; set; }
    }
}
