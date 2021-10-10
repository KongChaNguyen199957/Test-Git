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
    public class TeacherServices : ITeacherServices
    {
        private readonly AngularAPIContext _context;
        public TeacherServices(AngularAPIContext context)
        {
            _context = context;
        }        
        public async Task<List<TblTeachers>> GetAllAsync()
        {
            try
            {
                List<TblTeachers> teachers = await _context.TblTeachers.OrderBy(x => x.OrderNumber).ToListAsync();
                return teachers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblTeachers> GetByIdAsync(int id)
        {
            try
            {
                var teachers = new TblTeachers();
                teachers = await _context.TblTeachers.FindAsync(id);

                return teachers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> InsertAsync(TblTeachers model)
        {
            try
            {
                var teacher = new TblTeachers()
                {
                    TeacherCode = model.TeacherCode,
                    TeacherName = model.TeacherName,
                    TeacherEmail = model.TeacherEmail,
                    TeacherPhone = model.TeacherPhone,
                    TeacherGender = model.TeacherGender,
                    TeacherImage = model.TeacherImage,
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
        public async Task<ResponseModel> EditAsync(TblTeachers model)
        {
            try
            {
                TblTeachers entity = await _context.TblTeachers.FindAsync(model.Id);
                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy ID", StatusCode = StatusCodes.Status404NotFound };
                }

                entity.TeacherCode = model.TeacherCode;
                entity.TeacherName = model.TeacherName;
                entity.TeacherEmail = model.TeacherEmail;
                entity.TeacherPhone = model.TeacherPhone;
                entity.TeacherGender = model.TeacherGender;
                entity.TeacherImage = model.TeacherImage;
                entity.OrderNumber = model.OrderNumber;
                entity.CreateDate = model.CreateDate;

                //_context.Entry(entity).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();

                return new ResponseModel() { Message = "Sửa Thành Công", StatusCode = StatusCodes.Status200OK };
            }
            catch
            {
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Sửa Thất Bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }
        public async Task<ResponseModel> DeleteAsync(int id)
        {
            try
            {
                TblTeachers entity = await _context.TblTeachers.SingleOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                {
                    return new ResponseModel() { Message = "Không Tìm Thấy Id", StatusCode = StatusCodes.Status404NotFound };
                }

                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseModel() { Message = "Xoá Thành Công", StatusCode = StatusCodes.Status200OK };
            }
            catch 
            {
                await _context.SaveChangesAsync();

                return new ResponseModel() { Message = "Xoá Thất Bại", StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        public async Task<PagedResult<TblTeachers>> GetPaginationAsync(int pageIndex = 1, int pageSize = 15, string strSearch = null)
        {
            try
            {
                List<TblTeachers> entities = await _context.TblTeachers.ToListAsync();

                int totalPage = (int)Math.Ceiling((double)entities.Count / pageSize);
                int skip = (pageIndex - 1) * pageSize;

                PagedResult<TblTeachers> pageResult = new PagedResult<TblTeachers>()
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    TotalPage = totalPage,
                    TotalItem = entities.Count,
                    Results = entities.Skip(skip).Take(pageSize).ToList()
                };

                return pageResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckExistingCodeAsync(string code, int id = default)
        {
            try
            {
                TblTeachers tblTeachers = await _context.TblTeachers.FirstOrDefaultAsync(m => m.TeacherCode.ToUpper().Equals(code.ToUpper())
                    && m.Id != id);

                return tblTeachers != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
