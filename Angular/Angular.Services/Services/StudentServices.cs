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

namespace AngularAPI.Services.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly AngularAPIContext _context;
        public StudentServices(AngularAPIContext context)
        {
            _context = context;
        }

        public async Task<List<TblStudents>> GetAllStudentsAsync()
        {
            try
            {
                List<TblStudents> students = await _context.TblStudents.OrderBy(x => x.OrderNumber).ToListAsync();
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblStudents> GetStudentsByIdAsync(int id)
        {
            try
            {
                var students = new TblStudents();
                students = await _context.TblStudents.SingleOrDefaultAsync(x => x.Id == id);

                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> InsertStudentsAsync(TblStudents model)
        {
            try
            {
                var teacher = new TblStudents()
                {
                    StudentCode = model.StudentCode,
                    StudentName = model.StudentName,
                    StudentEmail = model.StudentEmail,
                    StudentPhone = model.StudentPhone,
                    StudentGender = model.StudentGender,
                    StudentImage = model.StudentImage,
                    ClassId = model.ClassId,
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

        public async Task<ResponseModel> EditStudentsAsync(TblStudents model)
        {
            try
            {
                TblStudents entity = await _context.TblStudents.FindAsync(model.Id);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                //_context.Entry(entity).CurrentValues.SetValues(model);

                entity.StudentCode = model.StudentCode;
                entity.StudentName = model.StudentName;
                entity.StudentEmail = model.StudentEmail;
                entity.StudentPhone = model.StudentPhone;
                entity.StudentGender = model.StudentGender;
                entity.StudentImage = model.StudentImage;
                entity.ClassId = model.ClassId;
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

        public async Task<ResponseModel> DeleteStudentAsync(int id)
        {
            try
            {
                TblStudents entity = await _context.TblStudents.FindAsync(id);

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

        public async Task<List<TblStudents>> GetAllStudentClass()
        {
            try
            {
                List<TblStudents> studentClass = await _context.TblStudents.Include(x => x.Class).OrderBy(x => x.OrderNumber).ToListAsync();
                return studentClass;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
