using Angular.Model.DTOs;
using Angular.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Interfaces
{
    public interface ISectionServices
    {
        Task<List<TblSections>> GetAllSectionClass();
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        Task<List<TblSections>> GetAllSectionAsync();
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblSections> GetSectionByIdAsync(int id);
        /// <summary>
        /// insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> InsertSectionAsync(TblSections model);
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseModel> EditSectionAsync(TblSections model);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseModel> DeleteSectionAsync(int id);


    }
}
