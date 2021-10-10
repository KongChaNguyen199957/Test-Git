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
    public class SubjectServices : ISubjectServices
    {
        private readonly AngularAPIContext _context;
        public SubjectServices(AngularAPIContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> InsertSubjectAsync(TblSubjects model)
        {
            try
            {
                var teacher = new TblSubjects()
                {
                    SubjectCode = model.SubjectCode,
                    SubjectName = model.SubjectName,
                    NumberOfPeriod = model.NumberOfPeriod,
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

        public async Task<ResponseModel> DeleteSubjectAsync(int id)
        {
            try
            {
                TblSubjects entity = await _context.TblSubjects.SingleOrDefaultAsync(x => x.Id == id);

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

        public async Task<ResponseModel> EditSubjectAsync(TblSubjects model)
        {
            try
            {
                TblSubjects entity = await _context.TblSubjects.FindAsync(model.Id);
                if (entity == null)
                { 
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }
                else
                {
                    entity.SubjectCode = model.SubjectCode;
                    entity.SubjectName = model.SubjectName;
                    entity.NumberOfPeriod = model.NumberOfPeriod;
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

        public async Task<List<TblSubjects>> GetAllSubjectAsync()
        {
            try
            {
                List<TblSubjects> subjects = await _context.TblSubjects.OrderBy(x => x.OrderNumber).ToListAsync();
                return subjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblSubjects> GetSubjectByIdAsync(int id)
        {
            try
            {
                var subjects = new TblSubjects();
                subjects = await _context.TblSubjects.FindAsync(id);

                return subjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
