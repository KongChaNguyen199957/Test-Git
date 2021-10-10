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
    public class ClassesServices : IClassesServices
    {
        private readonly AngularAPIContext _context;
        public ClassesServices(AngularAPIContext context)
        {
            _context = context;
        }
        public async Task<List<TblClasses>> GetAllClassAsync()
        {
            try
            {
                List<TblClasses> classes = await _context.TblClasses.OrderBy(x => x.OrderNumber).ToListAsync();
                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblClasses> GetClassByIdAsync(int id)
        {
            try
            {
                var classes = new TblClasses();
                classes = await _context.TblClasses.FindAsync(id);

                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseModel> DeleteClassAsync(int id)
        {
            try
            {
                TblClasses entity = await _context.TblClasses.SingleOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không tìm thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }
                else
                {
                    _context.Remove(entity);
                    await _context.SaveChangesAsync();
                    return new ResponseModel() { Message = "Xoá Thành Công", StatusCode = StatusCodes.Status200OK };
                }
               
            }
            catch (Exception ex)
            {
                string messageFailed = ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") ?
                    "Không thể xoá dữ liệu này" : "Xoá thất bại";

                return new ResponseModel() { Message = "Xoá thất bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        public async Task<ResponseModel> EditClassAsync(TblClasses model)
        {
            try
            {
                TblClasses entity = await _context.TblClasses.FindAsync(model.Id);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }
                else
                {
                    entity.ClassCode = model.ClassCode;
                    entity.ClassName = model.ClassName;
                    entity.DepartmentId = model.DepartmentId;
                    entity.TeacherId = model.TeacherId;
                    entity.OrderNumber = model.OrderNumber;
                    entity.CreateDate = model.CreateDate;

                    await _context.SaveChangesAsync();
                    return new ResponseModel() { Message = "Thêm Thành Công", StatusCode = StatusCodes.Status200OK };
                }
            }
            catch
            {
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Sửa Thất Bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        public async Task<ResponseModel> InsertClassAsync(TblClasses model)
        {
            try
            {
                var teacher = new TblClasses()
                {
                    ClassCode = model.ClassCode,
                    ClassName = model.ClassName,
                    DepartmentId = model.DepartmentId,
                    TeacherId = model.TeacherId,
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

        public async Task<List<TblClasses>> GetClassDepartmentTeacher()
        {
            try
            {
                List<TblClasses> classes = await _context.TblClasses.Include(x=>x.Department).Include(x=>x.Teacher)
                    .OrderBy(x => x.OrderNumber).ToListAsync();
                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
