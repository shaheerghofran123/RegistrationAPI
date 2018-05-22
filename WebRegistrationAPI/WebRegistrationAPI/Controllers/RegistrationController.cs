using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]UserToSave user)
        {
            string conString = "Data Source=DABEER-DEVELOPE; Initial Catalog=MyLocker; user id=sa; password=admin;";
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = conString;
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO userSample(username,password,first_name,last_name,dob,created,modified) VALUES('"+user.userName+"',sys.fn_varbintohexstr(HASHBYTES('MD5','"+user.password+"')),'shaheer','ghofran','"+user.dob+"','"+DateTime.Now+"',NULL)",sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return new JsonResult(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class UserToSave
        {
            public string userName { get; set; }
            public string password { get; set; }
            public DateTime dob { get; set;}
            public string first_name { get; set;}
            public string last_name { get; set; }
            public string email { get; set; }
            public string status { get; set; }
            public string NIN { get; set; }
        }
    }
}
