namespace Evershop.Tests.API.Events;

public class ClientEventArgs
{
    public ClientEventArgs(IRestClient client) => Client = client;

    public IRestClient Client { get; }
}