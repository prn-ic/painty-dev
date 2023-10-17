using PaintyDev.Libs.CustomResponseLib;
using PaintyDev.Libs.CustomResponseLib.StatusCodes;

namespace Authentication.BusinessLayer.Exceptions
{
    public class NotFoundException<T> : ExceptionBase
    {
        public NotFoundException() : base((int)ClientErrorCodes.NotFound, "Not found") { }
        public NotFoundException(string message)
            : base((int)ClientErrorCodes.NotFound, message) { }
        public NotFoundException(T data, string message = "Not found") :
            base(CustomResponse.NotFoundResult(data, message)) { }
    }
}
