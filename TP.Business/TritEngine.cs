using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TP.Business.Contracts;
using TP.Core;
using TP.Data.Contracts;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.TritModel;
using System.Linq;

namespace TP.Business
{
    public class TritEngine : BusinessEngineBase, ITritEngine
    {
        private readonly ITritRepository _tritRepository;

        public TritEngine( IMapper mapper, ITritRepository tritRepository) : base(mapper)
        {
            _tritRepository = tritRepository;
        }

        public Result<TritUpdateModel> Get(int id)
        {
            var result = new Result<TritUpdateModel>();

            try
            {
                var trit = _tritRepository.Get(id);
                if (trit == null)
                    throw new NullReferenceException(Keywords.ReadError);

                result.Data = _mapper.Map<TritUpdateModel>(trit);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.ReadError;
                throw ex;
            }
            return result;
        }

        public Result<List<TritListModel>> GetAll()
        {
            var result = new Result<List<TritListModel>>();

            try
            {
                var listOfTrit = _tritRepository.GetAll();
                var listOfTritMap = _mapper.Map<List<TritListModel>>(listOfTrit);

                result.Data = listOfTritMap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.ListReadError;
                throw ex;
            }

            return result;
        }

        public Result Create(TritCreateModel tritCreateModel)
        {
            var result = new Result();

            try
            {
                var db_trit = _tritRepository.GetAll().OrderByDescending(p => p.trit_id).FirstOrDefault();
                if (db_trit == null)
                {
                    tritCreateModel.trit_id = 1;
                }
                else
                {
                    tritCreateModel.trit_id = db_trit.trit_id + 1;
                }

                var trit = _mapper.Map<Trit>(tritCreateModel);
                _tritRepository.Add(trit);
                _tritRepository.Save();

                result.Message = Keywords.CreateInfo;


            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.CreateError;
                throw ex;
            }
            return result;
        }

        public Result Update(TritUpdateModel tritUpdateModel)
        {
            var result = new Result();

            try
            {
                var trit = _tritRepository.Get(tritUpdateModel.trit_id);
                var tritMap = (Trit)_mapper.Map(tritUpdateModel, trit, typeof(TritUpdateModel), typeof(Trit));
                _tritRepository.Update(tritMap, trit.trit_id);
                _tritRepository.Save();

                result.Message = Keywords.UpdateInfo;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.UpdateInfo;
                throw ex;
            }
            return result;
        }

        public Result Delete(int id)
        {
            var result = new Result();

            try
            {
                _tritRepository.DeleteById(id);
                _tritRepository.Save();

                result.Message = Keywords.DeleteInfo;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.DeleteError;
                throw ex;
            }
            return result;
        }

        public Result<List<TritListModel>> GetTritsByUserId(string user_id)
        {
            var result = new Result<List<TritListModel>>();

            try
            {
                var listOfCustomerContact = _tritRepository.FindAll(x => x.trit_user_id == user_id);
                var listOfCustomerContactMap = _mapper.Map<List<TritListModel>>(listOfCustomerContact);

                result.Data = listOfCustomerContactMap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Gösterilecek trit bulunamadı.";
            }
            return result;
        }

        public Result<List<TritOthersListModel>> GetTritsOfOthers(string user_id)
        {
            var result = new Result<List<TritOthersListModel>>();

            try
            {
                var listOfTritList = _tritRepository.GetTritOthers(user_id);
                var listOfCustomerContactMap = _mapper.Map<List<TritOthersListModel>>(listOfTritList);

                result.Data = listOfTritList;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Gösterilecek trit bulunamadı.";
            }
            return result;
        }
    }
}