using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblSchedules
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public  TblClasses Class { get; set; }
        public  TblSubjects Subject { get; set; }
        public  TblTeachers Teacher { get; set; }
    }
}
