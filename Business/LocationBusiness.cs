using AutoMapper;
using Pubinno.Core.Result;
using Pubinno.Models;
using Pubinno.Repositories;

namespace Pubinno.Business
{
    public class LocationBusiness
    {
        private readonly ILocationRepo _repo;
        private readonly IMapper _mapper;

        public LocationBusiness(ILocationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<bool>> NewLocation(LocationViewModel location)
        {
            try
            {
                var result = await _repo.NewLocation(_mapper.Map<Location>(location));
                return result;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        }

        public async Task<Result<bool>> EditLocation(LocationUpdateViewModel location)
        {
            try
            {
                var result = await _repo.EditLocation(_mapper.Map<Location>(location));
                return result;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        }

        public async Task<Result<bool>> DeleteLocation(int id)
        {
            try
            {
                var result = await _repo.DeleteLocation(id);
                return result;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        }

        public async Task<Result<LocationViewModel>> GetLocation(int id)
        {
            try
            {
                var result = await _repo.GetLocation(id);
                return _mapper.Map<LocationViewModel>(result);
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        }

        public async Task<Result<List<LocationViewModel>>> GetAllLocation()
        {
            try
            {
                var result = await _repo.GetAllLocation();
                return _mapper.Map<List<LocationViewModel>>(result);
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        }
    }
}
