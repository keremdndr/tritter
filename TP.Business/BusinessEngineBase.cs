using AutoMapper;
using System;
using TP.Business.Contracts;

namespace TP.Business
{
    public class BusinessEngineBase : IBusinessEngine
    {
        protected readonly IMapper _mapper;
        public BusinessEngineBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func)
        {
            try
            {
                 
                var result = func.Invoke();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}