using System.Web;
using System.Collections.Generic;

namespace ExcellProtecaoVeicular.Model.Entity
{
    public class UploadImages
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
        public HttpRequestBase _Request{ get; set; }
    }
}
