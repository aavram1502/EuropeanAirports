using System.Collections.Generic;

namespace Services
{
    public interface IHttpRequestService
    {
        List<T> SendRequest<T>(string jsonFeed);
    }
}
