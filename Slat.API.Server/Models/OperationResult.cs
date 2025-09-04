namespace Slat.API.Server
{
    public class OperationResult
    {
        public string ErrorMessage { get; set; }
        public bool Successful { get { return ErrorMessage == null; } }
        public object Result { get; set; }
        public int StatusCode { get; set; }
    }
}
