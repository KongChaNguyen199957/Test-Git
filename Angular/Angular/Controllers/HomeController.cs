using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Angular.Model.DTOs;
using Angular.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Angular.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAttendanceServices _attendanceServices;
        private readonly IClassesServices _classesServices;
        private readonly IDeparmentServices _deparmentServices;
        private readonly ISectionServices _sectionServices;
        private readonly IShedulesServices _schedulesServices;
        private readonly IStudentServices _studentServices;
        private readonly ISubjectServices _subjectServices;
        private readonly ITeacherServices _teacherServices;
        private readonly IStudentSubjectServices _studentSubjectServices;
        private readonly AngularAPIContext _context;
        public HomeController(IAttendanceServices attendanceServices, IClassesServices classesServices,
            IDeparmentServices deparmentServices, ISectionServices sectionServices,
            IShedulesServices schedulesServices, IStudentServices studentServices, ISubjectServices subjectServices,
            ITeacherServices teacherServices, IConfiguration configuration, AngularAPIContext context, IStudentSubjectServices studentSubjectServices)
        {
            _configuration = configuration;

            _attendanceServices = attendanceServices;
            _classesServices = classesServices;
            _deparmentServices = deparmentServices;
            _sectionServices = sectionServices;
            _schedulesServices = schedulesServices;
            _studentServices = studentServices;
            _subjectServices = subjectServices;
            _teacherServices = teacherServices;
            _studentSubjectServices = studentSubjectServices;
            _context = context;
        }
        #region Teachers
        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeacher()
        {
            try
            {
                var teachers = (await _teacherServices.GetAllAsync()).OrderBy(m => m.OrderNumber).ToList();

                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("teachers/{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            try
            {
                TblTeachers product = await _teacherServices.GetByIdAsync(id);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpPost("teachers/insert")]
        public async Task<IActionResult> InsertTeacherAsync(TblTeachers entity)
        {
            try
            {
                var teachers = await _teacherServices.InsertAsync(entity);

                Response.StatusCode = teachers.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("teachers/edit")]
        public async Task<IActionResult> EditBuildingAsync(TblTeachers entity)
        {
            try
            {
               var teachers = await _teacherServices.EditAsync(entity);

                Response.StatusCode = teachers.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại"); ;
            }
        }

        [HttpDelete("teachers/delete/{id}")]
        public async Task<IActionResult> DeleteTeacherAsync(int id)
        {
            try
            {
                var teachers = await _teacherServices.DeleteAsync(id);

                Response.StatusCode = teachers.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
        #endregion

        #region Department
        [HttpGet("department")]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                var departments = (await _deparmentServices.GetAllAsync()).OrderBy(m => m.OrderNumber).ToList();

                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("department/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                TblDepartments departments = await _deparmentServices.GetByIdAsync(id);

                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpPost("department/insert")]
        public async Task<IActionResult> InsertdepartmentAsync(TblDepartments entity)
        {
            try
            {
                var departments = await _deparmentServices.InsertAsync(entity);

                Response.StatusCode = departments.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("department/edit")]
        public async Task<IActionResult> EditdepartmentAsync(TblDepartments entity)
        {
            try
            {
                var departments = await _deparmentServices.EditAsync(entity);

                Response.StatusCode = departments.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Sửa Thất Bại");
            }
        }

        [HttpDelete("department/delete/{id}")]
        public async Task<IActionResult> DeletedepartmentAsync(int id)
        {
            try
            {
                var departments = await _deparmentServices.DeleteAsync(id);

                Response.StatusCode = departments.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch 
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
        #endregion

        #region Subject
        [HttpGet("subject")]
        public async Task<IActionResult> GetAllSubject()
        {
            try
            {
                var subjects = (await _subjectServices.GetAllSubjectAsync()).OrderBy(m => m.OrderNumber).ToList();

                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("subject/{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            try
            {
                TblSubjects subjects = await _subjectServices.GetSubjectByIdAsync(id);

                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpPost("subject/insert")]
        public async Task<IActionResult> InsertSubjectAsync(TblSubjects entity)
        {
            try
            {
                var sujects = await _subjectServices.InsertSubjectAsync(entity);

                Response.StatusCode = sujects.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("subject/edit")]
        public async Task<IActionResult> EditSubjectAsync(TblSubjects entity)
        {
            try
            {
                var subjects = await _subjectServices.EditSubjectAsync(entity);

                Response.StatusCode = subjects.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Sửa Thất Bại");
            }
        }

        [HttpDelete("subject/delete/{id}")]
        public async Task<IActionResult> DeleteSubjecttAsync(int id)
        {
            try
            {
                var subjects = await _subjectServices.DeleteSubjectAsync(id);

                Response.StatusCode = subjects.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
        #endregion

        #region Class
        [HttpGet("class")]
        public async Task<IActionResult> GetAllClass()
        {
            try
            {
                var classes = (await _classesServices.GetAllClassAsync()).OrderBy(m => m.OrderNumber).ToList();

                return Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("ClassDepartmentTeacher")]
        public async Task<IActionResult> GetClassDepartmentTeacher()
        {
            try
            {
                var classes = (await _classesServices.GetClassDepartmentTeacher()).OrderBy(m => m.OrderNumber).ToList();

                return Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("class/{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            try
            {
                TblClasses classes = await _classesServices.GetClassByIdAsync(id);

                return Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpPost("class/insert")]
        public async Task<IActionResult> InsertClassAsync(TblClasses entity)
        {
            try
            {
                var classes = await _classesServices.InsertClassAsync(entity);

                Response.StatusCode = classes.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("class/edit")]
        public async Task<IActionResult> EditClassAsync(TblClasses entity)
        {
            try
            {
                var classes = await _classesServices.EditClassAsync(entity);

                Response.StatusCode = classes.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Sửa Thất Bại");
            }
        }

        [HttpDelete("class/delete/{id}")]
        public async Task<IActionResult> DeleteClassAsync(int id)
        {
            try
            {
                var classes = await _classesServices.DeleteClassAsync(id);

                Response.StatusCode = classes.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch 
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
        #endregion

        #region Student
        [HttpGet("studentClass")]
        public async Task<IActionResult> GetAllStudentClass()
        {
            try
            {
                var studentClass = (await _studentServices.GetAllStudentClass()).OrderBy(m => m.OrderNumber).ToList();

                return Ok(studentClass);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("student")]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                var students = (await _studentServices.GetAllStudentsAsync()).OrderBy(m => m.OrderNumber).ToList();

                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                TblStudents students = await _studentServices.GetStudentsByIdAsync(id);

                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpPost("student/insert")]
        public async Task<IActionResult> InsertStudentAsync(TblStudents entity)
        {
            try
            {
                var students = await _studentServices.InsertStudentsAsync(entity);

                Response.StatusCode = students.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("student/edit")]
        public async Task<IActionResult> EditStudentAsync(TblStudents entity)
        {
            try
            {
                var students = await _studentServices.EditStudentsAsync(entity);

                Response.StatusCode = students.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Sửa Thất Bại");
            }
        }

        [HttpDelete("student/delete/{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                var students = await _studentServices.DeleteStudentAsync(id);

                Response.StatusCode = students.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
        #endregion

        #region Section Class
        [HttpGet("sectionClass")]
        public async Task<IActionResult> GetAllSectionClass()
        {
            try
            {
                //    var sectionClass = ( 
                //                        from a in _context.TblSections
                //                        join b in _context.TblDepartments
                //                        on a.DepartmentId equals b.Id
                //                        select new 
                //                        { 
                //                           SectionCode = a.SectionCode,
                //                           SectionName = a.SectionName,
                //                           NumerOfSession = a.NumberOfSession,
                //                           DepartmentCode = b.DepartmentCode
                //                        }
                //                       );
                //    var rslt = await sectionClass.ToListAsync();

                List<TblSections> rslt = await _context.TblSections.Include(e => e.Department).OrderBy(x =>x.OrderNumber).ToListAsync();

                return Ok(rslt);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpPost("section/insert")]
        public async Task<IActionResult> InsertSectionAsync(TblSections entity)
        {
            try
            {
                var sections = await _sectionServices.InsertSectionAsync(entity);

                Response.StatusCode = sections.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch 
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("section/edit")]
        public async Task<IActionResult> EditSectionAsync(TblSections entity)
        {
            try
            {
                var sections = await _sectionServices.EditSectionAsync(entity);

                Response.StatusCode = sections.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Sửa Thất Bại");
            }
        }

        [HttpDelete("section/delete/{id}")]
        public async Task<IActionResult> DeleteSectionAsync(int id)
        {
            try
            {
                var sections = await _sectionServices.DeleteSectionAsync(id);

                Response.StatusCode = sections.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
        #endregion

        #region Schedules
        [HttpGet("schedules")]
        public async Task<IActionResult> GetAllSchedule()
        {
            try
            {
                var model = (from sch in _context.TblSchedules
                             join sbjs in _context.TblSubjects on sch.SubjectId equals sbjs.Id
                             join clss in _context.TblClasses on sch.ClassId equals clss.Id
                             join tch in _context.TblTeachers on sch.TeacherId equals tch.Id
                             join dprt in _context.TblDepartments on clss.DepartmentId equals dprt.Id
                             
                             select new
                             {
                                 Id = sch.Id,
                                 ClassId = clss.Id,
                                 ClassCode = clss.ClassCode,
                                 ClassName = clss.ClassName,
                                 SubjectId = sbjs.Id,
                                 SubjectCode = sbjs.SubjectCode,
                                 SubjectName = sbjs.SubjectName,
                                 DepartmentId = dprt.Id,
                                 DepartmentCode = dprt.DepartmentCode,
                                 DepartmentName = dprt.DepartmentName,
                                 TeacherId = tch.Id,
                                 TeacherCode = tch.TeacherCode,
                                 TeacherName = tch.TeacherName,
                                 StartDate = sch.StartDate,
                                 EndDate = sch.EndDate,
                                 NumberOfPeriod = sbjs.NumberOfPeriod,
                                 CreateDate = sch.CreateDate,
                                 OrderNumber = sch.OrderNumber

                             });

                var rslt = await model.OrderBy(x=>x.OrderNumber).ToListAsync();
                return Ok(rslt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("schedules/insert")]
        public async Task<IActionResult> InsertScheduleAsync(TblSchedules entity)
        {
            try
            {
                var rslt = await _schedulesServices.InsertSchedulesAsync(entity);

                Response.StatusCode = rslt.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("schedules/edit")]
        public async Task<IActionResult> EditScheduleAsync(TblSchedules entity)
        {
            try
            {
                var rslt = await _schedulesServices.EditSchedulesAsync(entity);

                Response.StatusCode = rslt.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại"); ;
            }
        }

        [HttpDelete("schedules/delete/{id}")]
        public async Task<IActionResult> DeleteScheduleAsync(int id)
        {
            try
            {
                var rslt = await _schedulesServices.DeleteSchedulesAsync(id);

                Response.StatusCode = rslt.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
        #endregion

        #region StudentSubject(lớp môn học)

        [HttpGet("subjectClasses/{subjectId}")]
        public async Task<IActionResult> GetSubjectBy(int subjectId)
        {
            try
            {
                var model = (from sch in _context.TblSchedules
                             join sbjs in _context.TblSubjects on sch.SubjectId equals sbjs.Id
                             join stsbj in _context.TblStudentSubjects on sbjs.Id equals stsbj.SubjectId
                             join stus in _context.TblStudents on stsbj.StudentId equals stus.Id
                             join clss in _context.TblClasses on sch.ClassId equals clss.Id
                             join tch in _context.TblTeachers on sch.TeacherId equals tch.Id
                             join dprt in _context.TblDepartments on clss.DepartmentId equals dprt.Id
                             join atdc in _context.TblAttendances on stus.Id equals atdc.StudentId
                             where sbjs.Id == subjectId
                             select new
                             {
                                 Id = sch.Id,
                                 ClassId = clss.Id,
                                 ClassCode = clss.ClassCode,
                                 ClassName = clss.ClassName,
                                 SubjectId = sbjs.Id,
                                 SubjectCode = sbjs.SubjectCode,
                                 SubjectName = sbjs.SubjectName,
                                 DepartmentId = dprt.Id,
                                 DepartmentCode = dprt.DepartmentCode,
                                 DepartmentName = dprt.DepartmentName,
                                 TeacherId = tch.Id,
                                 TeacherCode = tch.TeacherCode,
                                 TeacherName = tch.TeacherName,
                                 StartDate = sch.StartDate,
                                 StudentId = stus.Id,
                                 StudentCode = stus.StudentCode,
                                 StudentName = stus.StudentName,
                                 EndDate = sch.EndDate,
                                 NumberOfPeriod = sbjs.NumberOfPeriod,
                                 CreateDate = sch.CreateDate,
                                 OrderNumber = atdc.OrderNumber,
                                 Present = atdc.Present,
                                 Absent = atdc.Absent,
                                 Reason = atdc.Reason

                             });

                var rslt = await model.OrderBy(x => x.OrderNumber).ToListAsync();
                return Ok(rslt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        [HttpGet("studentSubject")]
        public async Task<IActionResult> GetAllstudentSubject(int studentSubjectCode)
        {
            try
            {
                var rslt = (await _studentSubjectServices.GetAllAsync(studentSubjectCode)).OrderBy(m => m.OrderNumber).ToList();

                return Ok(rslt);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, ex.Message });
            }
        }

        [HttpGet("studentSubject/{subjectId}/{teacherId}")]
        public async Task<IActionResult> GetStudentSubjectById(int subjectId, int teacherId)
        {
            try
            {
                var model = (from a in _context.TblStudentSubjects
                             join b in _context.TblSubjects on a.SubjectId equals b.Id
                             join c in _context.TblStudents on a.StudentId equals c.Id
                             join d in _context.TblSchedules on b.Id equals d.SubjectId
                             join e in _context.TblTeachers on d.TeacherId equals e.Id
                             where b.Id == subjectId && e.Id == teacherId
                             select new
                             {
                                 TeacherCode = e.TeacherCode,
                                 TeacherName = e.TeacherName,
                                 StudentSubjectCode = a.StudentSubjectCode,
                                 StudentId = c.Id,
                                 StudentCode = c.StudentCode,
                                 StudentName = c.StudentName,
                                 SubjectId = b.Id,
                                 SubjectCode = b.SubjectCode,
                                 SubjectName = b.SubjectName,
                                 OrderNumber = a.OrderNumber,
                                 CreateDate = a.CreateDate
                             });

                var rslt = await model.OrderBy(x => x.OrderNumber).ToListAsync();
                return Ok(rslt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("studentSubject/{subjectId}")]
        public async Task<IActionResult> GetStudentSubjectById(int subjectId)
        {
            try
            {
                var model = (from a in _context.TblStudentSubjects
                             join b in _context.TblSubjects on a.SubjectId equals b.Id
                             join c in _context.TblStudents on a.StudentId equals c.Id
                             where b.Id == subjectId
                             select new
                             {
                                 StudentSubjectCode = a.StudentSubjectCode,
                                 StudentId = c.Id,
                                 StudentCode = c.StudentCode,
                                 StudentName = c.StudentName,
                                 SubjectId = b.Id,
                                 SubjectCode = b.SubjectCode,
                                 SubjectName = b.SubjectName,
                                 OrderNumber = a.OrderNumber,
                                 CreateDate = a.CreateDate
                             });

                var rslt = await model.OrderBy(x => x.OrderNumber).ToListAsync();
                return Ok(rslt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("studentSubject/insert")]
        public async Task<IActionResult> InsertStudentSubjectAsync(TblStudentSubject entity)
        {
            try
            {
                var teachers = await _studentSubjectServices.InsertAsync(entity);

                Response.StatusCode = teachers.StatusCode;
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }

        [HttpPut("studentSubject/edit")]
        public async Task<IActionResult> EditStudentSubjectAsync(TblStudentSubject entity)
        {
            try
            {
                var teachers = await _studentSubjectServices.EditAsync(entity);

                Response.StatusCode = teachers.StatusCode;
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại"); ;
            }
        }

        [HttpDelete("studentSubject/delete/{StudentSubjectCode}")]
        public async Task<IActionResult> DeleteStudentSubjectAsync(int StudentSubjectCode)
        {
            try
            {
                var teachers = await _studentSubjectServices.DeleteAsync(StudentSubjectCode);

                Response.StatusCode = teachers.StatusCode;
                return new JsonResult("Xoá Thành Công");
            }
            catch
            {
                return new JsonResult("Xoá Thất Bại");
            }
        }
    }
       
}
