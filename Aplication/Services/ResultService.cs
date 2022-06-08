﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class ResultService
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                Message = message,
                IsSucess = false,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }


        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                Message = message,
                IsSucess = false,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail(string message) => new ResultService { IsSucess = false, Message = message };
        public static ResultService Fail<T>(string message) => new ResultService { IsSucess = false, Message = message };

        internal static ResultService<T> Ok<T>(T personDTO)
        {
            throw new NotImplementedException();
        }

        public static ResultService Ok(string message) => new ResultService { IsSucess = true, Message = message };
        public static ResultService Ok<T>(string message) => new ResultService { IsSucess = true, Message = message };
    }

    public class ResultService<T> : ResultService
    { 
        public T Data { get; set; }   
    }

}

