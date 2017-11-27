using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Exo1.Controllers
{
    public class HomeController : ApiController
    {
        // GET: api/Home
        public IEnumerable<GetUserListResult> Get()
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var Users = MyContext.GetUserList().ToList();
            return Users;
        }

        // GET: api/Home/5
        public GetUserInfoResult Get(string id)
        {

            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var User = MyContext.GetUserInfo(Guid.Parse(id)).FirstOrDefault();
            return User;
        }
    }
}
