using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http;
using LocalRepositoryApplication.api.bower;
using System.Net.Http;

namespace LocalRepositoryApplication.api.products
{
    [RoutePrefix("bower")]
    public class BowerController : ApiController
    {
        Package[] packages = new Package[]
        {
            new Package { name = "Soup", url = "Packages"}
        };

        [Route("packages/search/{packagename}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public Package[] search(string packagename)
        {

            return new Package[] { packages[0] };
        }

    }
}
