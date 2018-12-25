using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TP.Business.Contracts;
using TP.Core;
using TP.Data.Contracts;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.UserModel;
using System.Linq;
using TP.Data.Entities.PageModels.TritModel;

namespace TP.Business
{
    public class UserEngine : BusinessEngineBase, IUserEngine
    {
        private readonly IUserRepository _userRepository;

        public UserEngine( IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            _userRepository = userRepository;
        }

        public Result<UserUpdateModel> Get(int id)
        {
            var result = new Result<UserUpdateModel>();

            try
            {
                var user = _userRepository.Get(id);
                if (user == null)
                    throw new NullReferenceException(Keywords.ReadError);

                result.Data = _mapper.Map<UserUpdateModel>(user);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.ReadError;
                throw ex;
            }
            return result;
        }

        public Result<List<UserListModel>> GetAll()
        {
            var result = new Result<List<UserListModel>>();

            try
            {
                var listOfUser = _userRepository.GetAll();
                var listOfUserMap = _mapper.Map<List<UserListModel>>(listOfUser);

                result.Data = listOfUserMap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.ListReadError;
                throw ex;
            }

            return result;
        }

        public Result Create(UserCreateModel userCreateModel)
        {
            var result = new Result();

            try
            {
                userCreateModel.user_isactive = 1;
                userCreateModel.user_createtime = DateTime.Now;

                var user = _mapper.Map<User>(userCreateModel);
                _userRepository.Add(user);
                _userRepository.Save();

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

        public Result Update(UserUpdateModel userUpdateModel)
        {
            var result = new Result();

            try
            {
                var user = _userRepository.FindBy(p => p.user_id == userUpdateModel.user_id).FirstOrDefault();
                var userMap = (User)_mapper.Map(userUpdateModel, user, typeof(UserUpdateModel), typeof(User));
                _userRepository.Update(userMap, user.user_id);
                _userRepository.Save();

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
                _userRepository.DeleteById(id);
                _userRepository.Save();

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

        public Result CheckUserLogin(string username, string password)
        {
            var result = new Result();

            try
            {
                var listOfUser = _userRepository.GetAll().Where(p => p.user_email == username && p.user_password == password && p.user_isactive == 1).FirstOrDefault().user_id;

                result.Content = listOfUser;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.ListReadError;
                //throw ex;
            }

            return result;

        }

        public Result<UserCreateModel> GetByUserId(string user_id)
        {
            var result = new Result<UserCreateModel>();

            try
            {
                var user = _userRepository.FindBy(p => p.user_id == user_id).FirstOrDefault();
                if (user == null)
                    throw new NullReferenceException(Keywords.ReadError);

                result.Data = _mapper.Map<UserCreateModel>(user);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.ReadError;
            }
            return result;
        }

        public Result<List<UserListModel>> SearchUser(string word)
        {
            var result = new Result<List<UserListModel>>();

            try
            {
                var listOfUser = _userRepository.GetAll();
                var listOfUserMap = _mapper.Map<List<UserListModel>>(listOfUser);

                result.Data = listOfUserMap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = Keywords.ListReadError;
                throw ex;
            }

            return result;
        }



    }
}