using Angular.Model.DTOs;
using Angular.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Interfaces
{
    public interface IShedulesServices
    {
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblSchedules> GetSchedulesByIdAsync(int id);
        /// <summary>
        /// insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> InsertSchedulesAsync(TblSchedules model);
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> EditSchedulesAsync(TblSchedules model);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseModel> DeleteSchedulesAsync(int id);
    }
}
