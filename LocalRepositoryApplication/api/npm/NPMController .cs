using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http;
using LocalRepositoryApplication.api.bower;
using System.Net.Http;

// Original API at 
//http://registry.npmjs.org/


namespace LocalRepositoryApplication.api.products
{
    [RoutePrefix("npm")]
    public class NPMController : ApiController
    {
        Package[] packages = new Package[]
        {
            new Package { name = "NPM", url = "Packages"}
        };

        [Route("{packagename}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Package[] search(string packagename)
        {

            return new Package[] { packages[0] };
        }

        [Route("")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Package[] defaultAction()
        {

            return new Package[] { packages[0] };
        }


    }
}
