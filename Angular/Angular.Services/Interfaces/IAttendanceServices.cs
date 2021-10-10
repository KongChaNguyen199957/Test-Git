using Angular.Model.DTOs;
using Angular.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Interfaces
{
    public interface IAttendanceServices
    {
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        Task<List<TblAttendances>> GetAllAttendanceAsync();
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblAttendances> GetAttendanceByIdAsync(int id);
        /// <summary>
        /// insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> InsertAttendanceAsync(TblAttendances model);
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> EditAttendanceAsync(TblAttendances model);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseModel> DeleteAttendanceAsync(int id);
    }
}
