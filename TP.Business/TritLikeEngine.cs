using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TP.Business.Contracts;
using TP.Core;
using TP.Data.Contracts;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.TritLikeModel;
using System.Linq;

namespace TP.Business
{
    public class TritLikeEngine : BusinessEngineBase, ITritLikeEngine
    {
        private readonly ITritLikeRepository _tritLikeRepository;

        public TritLikeEngine( IMapper mapper, ITritLikeRepository tritLikeRepository) : base(mapper)
        {
            _tritLikeRepository = tritLikeRepository;
        }

        //public Result<TritLikeUpdateModel> Get(int id)
        //{
        //    var result = new Result<TritLikeUpdateModel>();

        //    try
        //    {
        //        var tritLike = _tritLikeRepository.Get(id);
        //        if (tritLike == null)
        //            throw new NullReferenceException(Keywords.ReadError);

        //        result.Data = _mapper.Map<TritLikeUpdateModel>(tritLike);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = Keywords.ReadError;
        //        throw ex;
        //    }
        //    return result;
        //}

        //public Result<List<TritLikeListModel>> GetAll()
        //{
        //    var result = new Result<List<TritLikeListModel>>();

        //    try
        //    {
        //        var listOfTritLike = _tritLikeRepository.GetAll();
        //        var listOfTritLikeMap = _mapper.Map<List<TritLikeListModel>>(listOfTritLike);

        //        result.Data = listOfTritLikeMap;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = Keywords.ListReadError;
        //        throw ex;
        //    }

        //    return result;
        //}

        public Result Create(TritLikeCreateModel tritLikeCreateModel)
        {
            var result = new Result();

            try
            {
                var db_tritLike = _tritLikeRepository.GetAll().OrderByDescending(p => p.like_id).FirstOrDefault();
                if (db_tritLike == null)
                {
                    tritLikeCreateModel.like_id = 1;
                }
                else
                {
                    tritLikeCreateModel.like_id = db_tritLike.like_id + 1;
                }

                var tritLike = _mapper.Map<TritLike>(tritLikeCreateModel);
                _tritLikeRepository.Add(tritLike);
                _tritLikeRepository.Save();

                result.Message = Keywords.CreateInfo;


            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.CreateError;
                //throw ex;
            }
            return result;
        }

        //public Result Update(TritLikeUpdateModel tritLikeUpdateModel)
        //{
        //    var result = new Result();

        //    try
        //    {
        //        var tritLike = _tritLikeRepository.Get(tritLikeUpdateModel.tritLike_id);
        //        var tritLikeMap = (TritLike)_mapper.Map(tritLikeUpdateModel, tritLike, typeof(TritLikeUpdateModel), typeof(TritLike));
        //        _tritLikeRepository.Update(tritLikeMap, tritLike.tritLike_id);
        //        _tritLikeRepository.Save();

        //        result.Message = Keywords.UpdateInfo;

        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = Keywords.UpdateInfo;
        //        throw ex;
        //    }
        //    return result;
        //}

        //public Result Delete(int id)
        //{
        //    var result = new Result();

        //    try
        //    {
        //        _tritLikeRepository.DeleteById(id);
        //        _tritLikeRepository.Save();

        //        result.Message = Keywords.DeleteInfo;

        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = Keywords.DeleteError;
        //        throw ex;
        //    }
        //    return result;
        //}

        //public Result<List<TritLikeListModel>> GetTritLikesByUserId(string user_id)
        //{
        //    var result = new Result<List<TritLikeListModel>>();

        //    try
        //    {
        //        var listOfCustomerContact = _tritLikeRepository.FindAll(x => x.tritLike_user_id == user_id);
        //        var listOfCustomerContactMap = _mapper.Map<List<TritLikeListModel>>(listOfCustomerContact);

        //        result.Data = listOfCustomerContactMap;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = "Gösterilecek tritLike bulunamadı.";
        //    }
        //    return result;
        //}

        //public Result<List<TritLikeOthersListModel>> GetTritLikesOfOthers(string user_id)
        //{
        //    var result = new Result<List<TritLikeOthersListModel>>();

        //    try
        //    {
        //        var listOfTritLikeList = _tritLikeRepository.GetTritLikeOthers(user_id);
        //        var listOfCustomerContactMap = _mapper.Map<List<TritLikeOthersListModel>>(listOfTritLikeList);

        //        result.Data = listOfTritLikeList;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = "Gösterilecek tritLike bulunamadı.";
        //    }
        //    return result;
        //}
    }
}