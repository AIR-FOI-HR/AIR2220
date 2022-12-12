
namespace Breadr.Core.Domain
{
    public interface IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
