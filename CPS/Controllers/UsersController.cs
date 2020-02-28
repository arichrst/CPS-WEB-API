using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPS.Models;

namespace CPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : MastersController
    {
        [HttpPost("Login")]
        public BaseApiResponse<LoginViewModel.Response> Login(LoginViewModel.Request data)
        {
            CPSRequest<LoginViewModel.Response> request = new CPSRequest<LoginViewModel.Response>(this,false);
            return request.Execute("Users/Login", () => {
                var item = Db.User.FirstOrDefault(x=>x.Username == data.Username && x.Password == data.Password);
                if(item != null){

                    item.Token = Auth.GenerateToken();
                    Db.SaveChanges();
                    return new LoginViewModel.Response(item);
                }
                return null;
            }, data );
        }


        [HttpPost("Register")]
        public BaseApiResponse<RegisterViewModel.Response> Register(RegisterViewModel.Request param)
        {
            CPSRequest<RegisterViewModel.Response> request = new CPSRequest<RegisterViewModel.Response>(this,false);
            return request.Execute("Users/Register", () => {
                var item = Db.User.FirstOrDefault(x=>x.Username == param.Username && x.Password == param.Password);
                if(item == null){
                    item = new User();
                    item.Token = Auth.GenerateToken();
                    item.Username = param.Username;
                    item.Password = param.Password;
                    item.Name = param.Name;
                    item.Phone = param.Phone;
                    Db.User.Add(item);
                    Db.SaveChanges();
                    return new RegisterViewModel.Response(item);
                }
                return null;
            }, param);
        }

        [HttpPost("Logout")]
        public BaseApiResponse<bool> Logout()
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Users/Logout", () => {
                
                var item = Db.User.FirstOrDefault(x=>x.Token == request.Token);
                if(item != null){
                    
                    item.Token = null;
                    Db.User.Update(item);
                    Db.SaveChanges();
                    return true;
                }
                return false;
            });
        }

        
    }
}
