using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CML.AspNetCore.Authorization;
using CML.AspNetCore.Filters;
using CML.AspNetCore.Test.Model;
using CML.Lib;
using Microsoft.AspNetCore.Mvc;

namespace CML.AspNetCore.Test.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        // GET api/values
        [HttpGet]
        [ApiAuthorize("TEST")]
        public IEnumerable<string> Get()
        {
            throw new BizException("测试异常捕获");
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        [ApiAuthorize("TEST")]
        [ModelState]
        public string Get(DemoModel model)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
    }
}
