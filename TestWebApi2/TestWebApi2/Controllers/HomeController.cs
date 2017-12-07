using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebApi2.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        // GET: api/Home
        public IEnumerable<GetUserListResult> Get()
        {
            DataClasses1DataContext myContext = new DataClasses1DataContext();
            var Users = myContext.GetUserList().ToList();
            return Users;
        }

        // GET: api/Home/5
        public GetUserInfoResult Get(string token, string id)
        {
            Guid UserID = Guid.Parse(id);
            DataClasses1DataContext myContext = new DataClasses1DataContext();
            var user = myContext.GetUserInfo(Guid.Parse(id)).FirstOrDefault();
            return user;
        }

        [HttpPost]
        [Route("authenticate")]
        public Models.TokenResponse authenticate([FromBody] Models.AuthInfo user)
        {



            if (user.Username == "toto" && user.Password == "toto")
                return new Models.TokenResponse { Result = 1, Token = Guid.NewGuid() };
            else
                return new Models.TokenResponse { Result = 0, Token = Guid.Empty };
        }
    }
}
