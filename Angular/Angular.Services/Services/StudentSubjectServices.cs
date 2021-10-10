using Angular.Model.DTOs;
using Angular.Model.Models;
using Angular.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Services
{
    public class StudentSubjectServices : IStudentSubjectServices
    {
        private readonly AngularAPIContext _context;
        public StudentSubjectServices(AngularAPIContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> DeleteAsync(int StudentSubjectCode)
        {
            try
            {
                TblStudentSubject entity = await _context.TblStudentSubjects.FindAsync(StudentSubjectCode);

                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không tìm thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Xoá Thành Công", StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                string messageFailed = ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") ?
                    "Không thể xoá dữ liệu này" : "Xoá thất bại";

                return new ResponseModel() { Message = "Xoá thất bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        public async Task<ResponseModel> EditAsync(TblStudentSubject model)
        {
            try
            {
                TblStudentSubject entity = await _context.TblStudentSubjects.FindAsync(model.StudentSubjectCode);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                //_context.Entry(entity).CurrentValues.SetValues(model);

                entity.StudentSubjectCode = model.StudentSubjectCode;
                entity.SubjectId = model.SubjectId;
                entity.StudentId = model.StudentId;
                entity.OrderNumber = model.OrderNumber;
                entity.CreateDate = model.CreateDate;

                await _context.SaveChangesAsync();

                return new ResponseModel() { Message = "Sửa Thành Công", StatusCode = StatusCodes.Status200OK };
            }
            catch
            {
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Sửa Thất Bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        public async Task<List<TblStudentSubject>> GetAllAsync(int StudentSubjectCode)
        {
            try
            {
                List<TblStudentSubject> subjects = await _context.TblStudentSubjects
                    .Include(x => x.Subjects).Include(x => x.Students).Where(x => x.StudentSubjectCode == StudentSubjectCode)
                    .OrderBy(x => x.OrderNumber).ToListAsync();

                return subjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TblStudentSubject>> GetAllAsyncById(int subjectId)
        {
            try
            {
                List<TblStudentSubject> result = await _context.TblStudentSubjects.Where(m => m.SubjectId == subjectId).Include(m => m.Students)
                    .Include(m => m.Subjects).ThenInclude(m => m.TblSchedules).ThenInclude(m => m.Teacher)
                    .OrderBy(m => m.OrderNumber)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  Task<TblStudentSubject> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<ResponseModel> InsertAsync(TblStudentSubject model)
        {
            try
            {
                var teacher = new TblStudentSubject()
                {
                    StudentSubjectCode = model.StudentSubjectCode,
                    SubjectId = model.SubjectId,
                    StudentId = model.SubjectId,
                    OrderNumber = model.OrderNumber,
                    CreateDate = DateTime.Now
                };

                await _context.AddAsync(teacher);
                var rslt = await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Thêm Thành Công", StatusCode = StatusCodes.Status200OK };
            }
            catch
            {
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Thêm Thất Bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }
    }
}
