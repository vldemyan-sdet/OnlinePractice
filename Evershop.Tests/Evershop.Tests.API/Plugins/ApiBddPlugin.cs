using Evershop.Tests.API.Events;
using Evershop.Tests.API.Settings;

namespace Evershop.Tests.API.Plugins;

public class ApiBddPlugin : ApiClientPlugin
{
    public override void Enable()
    {
        if (ApiSettings.EnableBDDLogging)
        {
            base.Enable();
        }
    }

    public override void Disable()
    {
        if (ApiSettings.EnableBDDLogging)
        {
            base.Disable();
        }
    }

    protected override void OnRequestTimeout(object sender, ClientEventArgs client)
    {
        Console.WriteLine("Request was not executed in the specified timeout.");
    }

    protected override void OnMakingRequest(object sender, RequestEventArgs requestEventArgs)
    {
        var sb = new StringBuilder();
        sb.Append($"Making {requestEventArgs.Request.Method} request against resource {requestEventArgs.RequestResource}");
        if (requestEventArgs.Request.Parameters != null && requestEventArgs.Request.Parameters.Count > 0)
        {
            sb.Append(" with parameters ");
            foreach (var param in requestEventArgs.Request.Parameters)
            {
                sb.Append($"{param.Name}={param.Value} ");
            }
        }

        Console.WriteLine(sb.ToString().TrimEnd());
    }

    protected override void OnRequestMade(object sender, ResponseEventArgs responseEventArgs)
    {
        Console.WriteLine($"Response of request {responseEventArgs.Response.Request.Method} against resource {responseEventArgs.RequestUri} - {responseEventArgs.Response.ResponseStatus}");
    }

    protected override void OnRequestFailed(object sender, ResponseEventArgs responseEventArgs)
    {
        Console.WriteLine($"Request Failed {responseEventArgs.Response.Request.Method} on URL {responseEventArgs.RequestUri} - {responseEventArgs.Response.ResponseStatus} {responseEventArgs.Response.ErrorMessage}");
    }
}