using PaintyDev.Libs.CustomResponseLib;
using PaintyDev.Libs.CustomResponseLib.StatusCodes;

namespace Authentication.BusinessLayer.Exceptions
{
    public class InvalidDataException<T> : ExceptionBase
    {
        public InvalidDataException() : base((int)ClientErrorCodes.BadRequest, "Invalid data") { }
        public InvalidDataException(string message)
            : base((int)ClientErrorCodes.BadRequest, message) { }
        public InvalidDataException(T data, string message = "Invalid data") :
            base(CustomResponse.BadRequestResult(data, message)) { }
    }
}
