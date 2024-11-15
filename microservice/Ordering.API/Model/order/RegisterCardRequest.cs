using TypeGen.Core.TypeAnnotations;

namespace Ordering.API.Model.order
{
    [ExportTsInterface]
    public class RegisterCardRequest
    {
        public string AccountNumber { get; set; }
        public string PIN { get; set; }
        public string SerialNumber { get; set; }
    }
}
