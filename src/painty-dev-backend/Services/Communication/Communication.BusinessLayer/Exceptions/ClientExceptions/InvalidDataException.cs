using PaintyDev.Libs.CustomResponseLib;
using PaintyDev.Libs.CustomResponseLib.StatusCodes;

namespace Communication.BusinessLayer.Exceptions
{
    public class InvalidDataException<T> : ExceptionBase
    {
        public InvalidDataException() : base((int)ClientErrorCodes.BadRequest, "Invalid data") { }
        public InvalidDataException(string message)
            : base((int)ClientErrorCodes.BadRequest, message) { }
        public InvalidDataException(T data, string message = "Invalid data") :
            base(CustomResponse.BadRequestResult(data, message)) { }
        public InvalidDataException(T data, string[] parameters) :
            base(CustomResponse.BadRequestResult(data, 
                "Some parameters is incorrect: " + string.Join(";", parameters))) { }
        public InvalidDataException(string[] parameters) :
            base(CustomResponse.BadRequestResult(
                "Some parameters is incorrect: " + string.Join(";", parameters))) { }
    }
}
