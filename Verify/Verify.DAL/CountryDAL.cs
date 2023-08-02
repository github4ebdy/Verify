using Common.Core.Dto;
using Common.Core.ReturnModel;
using Common.Entity;
using Common.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Verify.Core.DAL;
using Verify.Core.Dto;

namespace Verify.DAL
{
    public class CountryDAL : ICountryDAL
    {
        ReturnFilterModel? filterModel;

        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<District> _districtRepository;
        private readonly IRepository<City> _cityRepository;

        public CountryDAL(IRepository<Country> countryRepository, IRepository<State> stateRepository, IRepository<District> districtRepository, IRepository<City> cityRepository)
        {
            _countryRepository = countryRepository;   
            _stateRepository = stateRepository;
            _districtRepository = districtRepository;
            _cityRepository = cityRepository;

        }
        public Task<Tuple<bool, string>> DeleteAsync(long Id)
        {
            throw new NotImplementedException();
        }
        public Task<ReturnFilterModel> GetAllAsync(FilterDto filter)
        {
            throw new NotImplementedException();
        }
        public async Task<CountryDto> GetAsync(long Id)
        {
            List<string> includecond = new List<string>
            {
                new string("StateList"),
                new string("StateList.DistrictList"),
                new string("StateList.DistrictList.CityList")

            };
            var returnvalue = (await _countryRepository.GetByIdAsync(Id, includecond));
            var createdentity = EntityToModelListDetails(returnvalue).FirstOrDefault();
            return returnvalue is null ? null : createdentity;
        }
        private IEnumerable<CountryDto> EntityToModelListDetails(IEnumerable<Country> returnvalue)
        {
            return returnvalue.Select(entity => new CountryDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.CountryName,
                isActive = entity.Active,
                StateList = entity.StateList == null ? null : entity.StateList.Select(m => new StateDto
                {
                    Id = m.Id,
                    Code = m.Code,
                    Name = m.StateName,
                    isActive = m.Active,
                    DistrictList = m.DistrictList == null ? null : m.DistrictList.Select(n => new DistrictDto
                    {
                        Id = n.Id,
                        Code = n.Code,
                        Name = n.DistrictName,
                        isActive = n.Active,
                    }).ToList()
                }).ToList()
            }).ToList();
        }
        public async Task<Tuple<CountryDto, string>> InsertAsync(CountryDto model)
        {
            try
            {
                string valMessage = string.Empty;

                if (string.IsNullOrEmpty(valMessage))
                {


                    var newitem = ModelToEntity(model);
                    var createditem = await _countryRepository.InsertAsync(newitem);
                    if (createditem != null)
                    {

                        var createditemDet = GetAsync(createditem.Id).Result;
                        return new Tuple<CountryDto, string>(createditemDet, valMessage);
                    }
                    else
                    {
                        return new Tuple<CountryDto, string>(null, valMessage);
                    }
                }
                else
                {
                    return new Tuple<CountryDto, string>(null, valMessage);
                }
            }
            catch(Exception ex)
            {
                return new Tuple<CountryDto, string>(null, ex.Message);
            }
        }    
        public async Task<Tuple<bool, string>> UpdateAsync(CountryDto model)
        {
            string valMessage = string.Empty;
            bool updateResponse = false;
            if (valMessage == string.Empty)
            {

                var statelst = model.StateList?.Where(x => x.Id > 0).Select(x => x.Id).ToList();
                await _stateRepository.DeleteBulk(x => x.Country_Id == model.Id && (statelst != null ? !statelst.Contains(x.Id) : true));

                if (model.StateList is not null)
                {
                    foreach (var state in model.StateList)
                    {
                        var districtlst = state.DistrictList?.Where(x => x.Id > 0).Select(x => x.Id).ToList();
                        await _districtRepository.DeleteBulk(x => x.State_Id == state.Id && (districtlst != null ? !districtlst.Contains(x.Id) : true));

                        if (state.DistrictList is not null)
                        {
                            foreach (var district in state.DistrictList)
                            {
                                var citylst = district.CityList?.Where(x => x.Id > 0).Select(x => x.Id).ToList();
                                await _cityRepository.DeleteBulk(x => x.District_Id == district.Id && (citylst != null ? !citylst.Contains(x.Id) : true));
                            }
                        }
                    }
                }

                var country = ModelToEntityCountry(model);
                updateResponse = await _countryRepository.InsertUpdate(country);

                foreach (var stateitm in model.StateList)
                {
                    var state = ModelToEntityState(stateitm);
                    state.Country_Id=model.Id;
                    updateResponse = await _stateRepository.InsertUpdate(state);

                     
                    foreach (var districtitm in stateitm.DistrictList)
                    {
                        var district = ModelToEntityDistrict(districtitm);
                        district.State_Id = state.Id;
                        updateResponse = await _districtRepository.InsertUpdate(district);

                        foreach (var cityitm in districtitm.CityList)
                        {
                            var city = ModelToEntityCity(cityitm);
                            city.District_Id = district.Id;
                            updateResponse = await _cityRepository.InsertUpdate(city);
                        }
                    }
                }

                
            }
            return new Tuple<bool, string>(updateResponse, valMessage);
        }
        private Country ModelToEntity(CountryDto model)
        {
            return new Country
            {
                Id = model.Id,
                Code = model.Code,
                CountryName = model.Name,
                Active = model.isActive ?? true,
                StateList = model.StateList == null ? null : model.StateList.Select(x => new State
                {
                    Id = x.Id,
                    Country_Id = model.Id, //FK
                    Code = x.Code,
                    StateName = x.Name,
                    Active = x.isActive ?? true,
                    DistrictList = x.DistrictList == null ? null : x.DistrictList.Select(y => new District
                    {
                        Id = y.Id,
                        State_Id = x.Id, //FK
                        Code = y.Code,
                        DistrictName = y.Name,
                        Active = y.isActive ?? true,
                        CityList = y.CityList == null ? null : y.CityList.Select(z => new City
                        {
                            Id = z.Id,
                            District_Id = y.Id, //FK
                            Code = z.Code,
                            CityName = z.Name,
                            Active = z.isActive ?? true
                        }).ToList(),
                    }).ToList()

                }).ToList()
            };
        }
        private Country ModelToEntityCountry(CountryDto model)
        {
            return new Country
            {
                Id = model.Id,
                Code = model.Code,
                CountryName = model.Name,
                Active = model.isActive ?? true
                
            };
        }
        private State ModelToEntityState(StateDto model)
        {
            return new State
            {
                Id = model.Id,
                Code = model.Code,
                StateName = model.Name,
                Active = model.isActive ?? true

            };
        }
        private District ModelToEntityDistrict(DistrictDto model)
        {
            return new District
            {
                Id = model.Id,
                Code = model.Code,
                DistrictName = model.Name,
                Active = model.isActive ?? true

            };
        }
        private City ModelToEntityCity(CityDto model)
        {
            return new City
            {
                Id = model.Id,
                Code = model.Code,
                CityName = model.Name,
                Active = model.isActive ?? true

            };
        }
    }
}
