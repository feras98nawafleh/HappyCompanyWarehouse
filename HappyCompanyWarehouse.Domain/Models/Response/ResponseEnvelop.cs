using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Domain.Models.Response
{
    public class ResponseEnvelop<T>
    {
        //public ResponseEnvelop(bool success, T result, HttpStatusCode statusCode, string resultMessage)
        //{
        //    Success = success;
        //    Result = result;
        //    StatusCode = statusCode;
        //    ResultMessage = resultMessage;
        //}

        public bool Success { get; set; }
        public ResponseEnvelop<T> SetSuccess(bool success)
        {
            Success = success;
            return this;
        }

        public T ResultData { get; set; }
        public ResponseEnvelop<T> SetResult(T result)
        {
            ResultData = result;
            return this;
        }

        public HttpStatusCode StatusCode { get; set; }
        public ResponseEnvelop<T> SetStatusCode(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        public string ResultMessage { get; set; }
        public ResponseEnvelop<T> SetResultMessage(string resultMessage)
        {
            ResultMessage = resultMessage;
            return this;
        }

        public ResponseEnvelop<T> Build()
        {
            return this;
        }
    }
}
