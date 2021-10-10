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
    public class SectionServices : ISectionServices
    {
        private readonly AngularAPIContext _context;
        public SectionServices(AngularAPIContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> DeleteSectionAsync(int id)
        {
            try
            {
                TblSections entity = await _context.TblSections.FindAsync(id);

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

        public async Task<ResponseModel> EditSectionAsync(TblSections model)
        {
            try
            {
                TblSections entity = await _context.TblSections.FindAsync(model.Id);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                entity.SectionCode = model.SectionCode;
                entity.SectionName = model.SectionName;
                entity.NumberOfSession = model.NumberOfSession;
                entity.DepartmentId = model.DepartmentId;
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

        public async Task<List<TblSections>> GetAllSectionAsync()
        {
            try
            {
                List<TblSections> schedules = await _context.TblSections.OrderBy(x => x.OrderNumber).ToListAsync();
                return schedules;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  Task<List<TblSections>> GetAllSectionClass()
        {
            throw new NotImplementedException();
        }

        public async Task<TblSections> GetSectionByIdAsync(int id)
        {
            try
            {
                var schedules = new TblSections();
                schedules = await _context.TblSections.FindAsync(id);

                return schedules;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> InsertSectionAsync(TblSections model)
        {
            try
            {
                var teacher = new TblSections()
                {
                    SectionCode = model.SectionCode,
                    SectionName = model.SectionName,
                    NumberOfSession = model.NumberOfSession,
                    DepartmentId = model.DepartmentId,
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
