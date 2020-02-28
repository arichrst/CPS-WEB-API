using System;
using System.Linq;
using CPS.Models;
using CPS.Controllers;
using System.Threading.Tasks;

namespace CPS
{
    public class CPSRequest<T>
    {
        public string Token { get; set; }
        public User User { get; set; }
        public DateTime RequestTime { get; set; }
        public MastersController Controller { get; set; }

        bool TokenChecking;
        public CPSRequest(MastersController controller, bool isTokenChecking = true)
        {
            RequestTime = DateTime.UtcNow;
            Controller = controller;
            TokenChecking = isTokenChecking;
        }

        public bool IsTokenAlive()
        {
            return true;
        }

        public BaseApiResponse<T> Execute(string url,Func<T> action, object param = null , string message = "" )
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("CALL API : " + url + " ===================================");
            Console.WriteLine("PARAM : " + Newtonsoft.Json.JsonConvert.SerializeObject(param, Newtonsoft.Json.Formatting.Indented));
           
            var result = action();
            if(TokenChecking)
            {
                if(!IsTokenAlive())
                    return Unauthorized(result);
            }
            try
            {
                if(result == null)
                    return Failure(result,"No Data");
                return Success(result,result == null ? "No Data" : message);
            }
            catch(Exception e)
            {
                return Failure(result,e.Message);
            }
        
        }

        public async Task<BaseApiResponse<T>> ExecuteAsync(string url, Func<Task<T>> action, object param = null , string message = "")
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("CALL API : " + url + " ===================================");
            Console.WriteLine("PARAM : " + Newtonsoft.Json.JsonConvert.SerializeObject(param, Newtonsoft.Json.Formatting.Indented));

            
            var result = action();
            if(TokenChecking)
            {
                if(!IsTokenAlive())
                    return await UnauthorizedAsync(result);
            }
            try{
                if(result == null)
                    return await FailureAsync(result,"No Data");
                return await SuccessAsync(result,result == null ? "No Data" : message);
            }catch(Exception e)
            {
                return await FailureAsync(result,e.Message);
            }
        }

        void RecordResponse(BaseApiResponse<T> content, string message)
        {
            Console.WriteLine("\nRESPONSE : " + Newtonsoft.Json.JsonConvert.SerializeObject(content, Newtonsoft.Json.Formatting.Indented));
            Console.WriteLine("\nMESSAGE : " + message);
            Console.WriteLine("\nEND OF CALL API ========================================");
            Console.WriteLine("\n\n\n");
        }

        public BaseApiResponse<T> Success(T content , string message = "")
        {
            var result = new BaseApiResponse<T>(content,true,RequestTime,message.IsEmpty() ? "Successfully retreiving data" : message);
            RecordResponse(result,message.IsEmpty() ? "Successfully retreiving data" : message);
            return result;
        }

        public async Task<BaseApiResponse<T>> SuccessAsync(Task<T> content , string message = "")
        {
            var result = new BaseApiResponse<T>(await content,true,RequestTime,message.IsEmpty() ? "Successfully retreiving data" : message);
            RecordResponse(result,message.IsEmpty() ? "Successfully retreiving data" : message);
            return result;
        }

        public async Task<BaseApiResponse<T>> FailureAsync(Task<T> content , string message = "")
        {
            var result = new BaseApiResponse<T>(await content,false,RequestTime,message.IsEmpty() ? "Unknown error detected" : message);
            RecordResponse(result,message.IsEmpty() ? "Unknown error detected" : message);
            return result;
        }
        public BaseApiResponse<T> Failure(T content , string message = "")
        {
            var result = new BaseApiResponse<T>(content,false,RequestTime,message.IsEmpty() ? "Unknown error detected" : message);
            RecordResponse(result,message.IsEmpty() ? "Unknown error detected" : message);
            return result;
        }

        public async Task<BaseApiResponse<T>> UnauthorizedAsync(Task<T> content)
        {
            var result = new BaseApiResponse<T>(await content,false,RequestTime,"Unauthorized");
            result.IsLoginRequired = true;
            RecordResponse(result,"Unauthorized");
            return result;
        }
        public BaseApiResponse<T> Unauthorized(T content)
        {
            var result = new BaseApiResponse<T>(content,false,RequestTime,"Unauthorized");
            result.IsLoginRequired = true;
            RecordResponse(result,"Unauthorized");
            return result;
        }
    }
}