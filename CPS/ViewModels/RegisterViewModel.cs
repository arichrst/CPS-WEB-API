using CPS.Models;

namespace CPS
{
    public class RegisterViewModel
    {
        public class Request
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }


        public class Response
        {
            public int Id { get; set; }
            public string Token { get; set; }
            public string Name { get; set; }

            public Response(User data)
            {
                if(data != null){
                Id = data.Id;
                Token = data.Token;
                Name = data.Name;
                }
            }
        }
    }
}