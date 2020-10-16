namespace Logging.Graylogs.Internal
{
    public class RequestContext
    {
        public RequestContext(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}