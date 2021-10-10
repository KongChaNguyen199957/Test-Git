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
    public class ScheduleServices : IShedulesServices
    {
        private readonly AngularAPIContext _context;
        public ScheduleServices(AngularAPIContext context)
        {
            _context = context;
        }
        
        public async Task<TblSchedules> GetSchedulesByIdAsync(int id)
        {
            try
            {
                var schedules = new TblSchedules();
                schedules = await _context.TblSchedules.FindAsync(id);

                return schedules;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> InsertSchedulesAsync(TblSchedules model)
        {
            try
            {
                var teacher = new TblSchedules()
                {
                    TeacherId = model.TeacherId,
                    SubjectId = model.SubjectId,
                    ClassId = model.ClassId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
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

        public async Task<ResponseModel> DeleteSchedulesAsync(int id)
        {
            try
            {
                TblSchedules entity = await _context.TblSchedules.SingleOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không tìm thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Xoá Thành Công", StatusCode = StatusCodes.Status200OK };
            }
            catch
            {
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Xoá thất bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        public async Task<ResponseModel> EditSchedulesAsync(TblSchedules model)
        {
            try
            {
                TblSchedules entity = await _context.TblSchedules.FindAsync(model.Id);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                entity.TeacherId = model.TeacherId;
                entity.SubjectId = model.SubjectId;
                entity.ClassId = model.ClassId;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
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

       
    }
}
