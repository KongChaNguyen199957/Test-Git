using Angular.Model.DTOs;
using Angular.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Interfaces
{
    public interface IStudentServices
    {
        Task<List<TblStudents>> GetAllStudentClass();
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        Task<List<TblStudents>> GetAllStudentsAsync();
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblStudents> GetStudentsByIdAsync(int id);
        /// <summary>
        /// insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> InsertStudentsAsync(TblStudents model);
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> EditStudentsAsync(TblStudents model);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseModel> DeleteStudentAsync(int id);
    }
}
