using Common.Core.Dto;
using Common.Core.ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verify.Core.Dto;

namespace Verify.Core.DAL
{
    public interface ICountryDAL
    {
        Task<CountryDto> GetAsync(long Id);
        Task<ReturnFilterModel> GetAllAsync(FilterDto filter);
        Task<Tuple<CountryDto, string>> InsertAsync(CountryDto model);
        Task<Tuple<bool, string>> UpdateAsync(CountryDto model);
        Task<Tuple<bool, string>> DeleteAsync(long Id);
      
    }
}
