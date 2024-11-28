using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace WebApi;

public class SenderService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        var _client = new ServiceBusClient(
            "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;");
        var _sender = _client.CreateSender("queue.1");
        
        while(true)
        {
            await _sender.SendMessageAsync(new ServiceBusMessage($"Hello World {DateTime.Now}"));
            await Task.Delay(1000);
            Console.WriteLine("Sending message");
        }
    }
}