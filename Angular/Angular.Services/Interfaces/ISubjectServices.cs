using Angular.Model.DTOs;
using Angular.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Interfaces
{
    public interface ISubjectServices
    {
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        Task<List<TblSubjects>> GetAllSubjectAsync();
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblSubjects> GetSubjectByIdAsync(int id);
        /// <summary>
        /// insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> InsertSubjectAsync(TblSubjects model);
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> EditSubjectAsync(TblSubjects model);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseModel> DeleteSubjectAsync(int id);
    }
}
