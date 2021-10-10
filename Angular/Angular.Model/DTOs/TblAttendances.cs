using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblAttendances
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public bool? Present { get; set; }
        public bool? Absent { get; set; }
        public string Reason { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public TblStudents Student { get; set; }
    }
}
