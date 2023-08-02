using Common.Core.ReturnModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verify.Core.Dto;
using Verify.Core.Services;
using Verify.Service;

namespace Verify.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        readonly ICountryService _countryService;
        public ValuesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ReturnVModel> Get(long Id)
        {
            var returnValue = await _countryService.GetAsync(Id);
            Response.StatusCode = returnValue.StatusCode;
            return returnValue;
        }

        [HttpPost]
        public async Task<ReturnVModel> Post(CountryDto model)
        {
            var returnValue = await _countryService.InsertAsync(model);
            Response.StatusCode = returnValue.StatusCode;
            return returnValue;
        }


        [HttpPut]
        public async Task<ReturnVModel> Put(CountryDto model)
        {
            var returnValue = await _countryService.UpdateAsync(model);
            Response.StatusCode = returnValue.StatusCode;
            return returnValue;
        }
    }
}
