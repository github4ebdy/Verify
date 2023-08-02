using Common.Core.Dto;
using Common.Core.ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verify.Core.Dto;

namespace Verify.Core.Services
{
    public interface ICountryService
    {
        Task<ReturnVModel> GetAsync(long Id);
        Task<ReturnVModel> GetAllAsync(FilterDto filter);
        Task<ReturnVModel> InsertAsync(CountryDto model);
        Task<ReturnVModel> UpdateAsync(CountryDto model);
        Task<ReturnVModel> DeleteAsync(long Id);
    }
}
