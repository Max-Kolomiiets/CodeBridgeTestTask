using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.DAL.Helpers
{
    public class SortingParams
    {
        [FromQuery(Name ="attribute")] 
        public string Attribute { get; set; }
        [FromQuery(Name = "order")]
        public string Order { get; set; }
    }
}
