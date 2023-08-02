using Common.Core.Dto;
using Common.Core.ReturnModel;
using Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verify.Core.DAL;
using Verify.Core.Dto;
using Verify.Core.Services;

namespace Verify.Service
{
    public class CountryService:ICountryService
    {
        readonly ICountryDAL parentDAL;
        ReturnVModel? returnModel;
        public CountryService(ICountryDAL parentDAL)
        {
            this.parentDAL = parentDAL;
        }
        public async Task<ReturnVModel> GetAsync(long Id)
        {
            returnModel = new ReturnVModel("", await parentDAL.GetAsync(Id), HttpResponseCode.HttpStatusCode_Ok);
            return returnModel;
        }
        public async Task<ReturnVModel> GetAllAsync(FilterDto filter)
        {
            returnModel = new ReturnVModel("", await parentDAL.GetAllAsync(filter), HttpResponseCode.HttpStatusCode_Ok);
            return returnModel;
        }
        public async Task<ReturnVModel> InsertAsync(CountryDto model)
        {
            try
            {

                if (1 == 1)
                {
                    Tuple<CountryDto, string> insertResponse = await parentDAL.InsertAsync(model);
                    if (insertResponse.Item1 is null)
                    {
                        returnModel = new ReturnVModel(insertResponse.Item2, null, HttpResponseCode.HttpStatusCode_BadRequest);
                    }
                    else
                    {
                        returnModel = new ReturnVModel(insertResponse.Item2, insertResponse.Item1, HttpResponseCode.HttpStatusCode_Created);
                    }
                }
                else
                {
                    returnModel = new ReturnVModel("Error", null, HttpResponseCode.HttpStatusCode_ValidationError);
                }
            }
            catch (Exception ex)
            {
                returnModel = new ReturnVModel(ex.Message, null, HttpResponseCode.HttpStatusCode_ValidationError);
            }

            return returnModel;
        }
        public async Task<ReturnVModel> UpdateAsync(CountryDto model)
        {

            
            if (1==1)
            {
                Tuple<bool, string> updateResponse = await parentDAL.UpdateAsync(model);
                if (updateResponse.Item1)
                {
                    returnModel = new ReturnVModel("", model, HttpResponseCode.HttpStatusCode_Created);

                }
                else
                {
                    returnModel = new ReturnVModel(updateResponse.Item2, null, HttpResponseCode.HttpStatusCode_BadRequest);
                }
            }
            else
            {
                returnModel = new ReturnVModel("Error", null, HttpResponseCode.HttpStatusCode_ValidationError);
            }

            return returnModel;
        }
        public async Task<ReturnVModel> DeleteAsync(long Id)
        {
            if (1==1)
            {
                Tuple<bool, string> updateResponse = await parentDAL.DeleteAsync(Id);
                if (updateResponse.Item1)
                {
                    returnModel = new ReturnVModel("", Id, HttpResponseCode.HttpStatusCode_Created);

                }
                else
                {
                    returnModel = new ReturnVModel(updateResponse.Item2, null, HttpResponseCode.HttpStatusCode_BadRequest);
                }
            }
            else
            {
                returnModel = new ReturnVModel("Error", null, HttpResponseCode.HttpStatusCode_ValidationError);
            }

            return returnModel;
        }
    }
}
