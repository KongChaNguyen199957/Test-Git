using Angular.Model.DTOs;
using Angular.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Services.Interfaces
{
    public interface IDeparmentServices
    {
        Task<List<TblDepartments>> GetAllAsync();
        Task<TblDepartments> GetByIdAsync(int id);
        Task<ResponseModel> InsertAsync(TblDepartments model);
        Task<ResponseModel> EditAsync(TblDepartments model);
        Task<ResponseModel> DeleteAsync(int id);

    }
}
