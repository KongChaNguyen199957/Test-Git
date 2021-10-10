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
    public class AttendanceServices : IAttendanceServices
    {
        private readonly AngularAPIContext _context;
        public AttendanceServices(AngularAPIContext context)
        {
            _context = context;
        }

        public async Task<List<TblAttendances>> GetAllAttendanceAsync()
        {
            try
            {
                List<TblAttendances> attendances = await _context.TblAttendances.OrderBy(x => x.OrderNumber).ToListAsync();
                return attendances;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblAttendances> GetAttendanceByIdAsync(int id)
        {
            try
            {
                var attendances = new TblAttendances();
                attendances = await _context.TblAttendances.FindAsync(id);

                return attendances;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> InsertAttendanceAsync(TblAttendances model)
        {
            try
            {
                var teacher = new TblAttendances()
                {
                    StudentId = model.StudentId,
                    Present = model.Present,
                    Absent = model.Absent,
                    Reason = model.Reason,
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
        public async Task<ResponseModel> EditAttendanceAsync(TblAttendances model)
        {
            try
            {
                TblAttendances entity = await _context.TblAttendances.FindAsync(model.Id);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                entity.StudentId = model.StudentId;
                entity.Present = model.Present;
                entity.Absent = model.Absent;
                entity.Reason = model.Reason;
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

        public async Task<ResponseModel> DeleteAttendanceAsync(int id)
        {
            try
            {
                TblAttendances entity = await _context.TblAttendances.FindAsync(id);

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
    }
}
