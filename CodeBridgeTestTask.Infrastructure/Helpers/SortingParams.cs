using Microsoft.AspNetCore.Mvc;

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
