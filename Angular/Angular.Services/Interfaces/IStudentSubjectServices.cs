using Angular.Model.DTOs;
using Angular.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Interfaces
{
    public interface IStudentSubjectServices
    {
        Task<List<TblStudentSubject>> GetAllAsyncById(int subjectId);

        /// <summary>
        /// get all 
        /// </summary>
        /// <returns></returns>
        Task<List<TblStudentSubject>> GetAllAsync(int StudentSubjectCode);
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblStudentSubject> GetByIdAsync(int id);
        /// <summary>
        /// insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> InsertAsync(TblStudentSubject model);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> EditAsync(TblStudentSubject model);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseModel> DeleteAsync(int StudentSubjectCode);
    }
}
