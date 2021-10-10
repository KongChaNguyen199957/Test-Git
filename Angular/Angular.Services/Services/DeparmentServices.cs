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
    public class DeparmentServices : IDeparmentServices
    {
        private readonly AngularAPIContext _context;
        public DeparmentServices(AngularAPIContext context)
        {
            _context = context;
        }

        public async Task<List<TblDepartments>> GetAllAsync()
        {
            try
            {
                List<TblDepartments> departments = await _context.TblDepartments.OrderBy(x => x.OrderNumber).ToListAsync();
                return departments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblDepartments> GetByIdAsync(int id)
        {
            try
            {
                var departments = new TblDepartments();
                departments = await _context.TblDepartments.FindAsync(id);

                return departments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseModel> InsertAsync(TblDepartments model)
        {
            try
            {
                var teacher = new TblDepartments()
                {
                    DepartmentCode = model.DepartmentCode,
                    DepartmentName = model.DepartmentName,
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

        public async Task<ResponseModel> DeleteAsync(int id)
        {
            try
            {
                TblDepartments entity = await _context.TblDepartments.SingleOrDefaultAsync(x => x.Id == id);

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

        public async Task<ResponseModel> EditAsync(TblDepartments model)
        {
            try
            {
                TblDepartments entity = await _context.TblDepartments.FindAsync(model.Id);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                entity.DepartmentCode = model.DepartmentCode;
                entity.DepartmentName = model.DepartmentName;
                entity.OrderNumber = model.OrderNumber;
                entity.CreateDate = model.CreateDate;

                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Thêm Thành Công", StatusCode = StatusCodes.Status200OK };
            }
            catch
            {
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Sửa Thất Bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }               

    }
}
