using Azure.Messaging.ServiceBus;

namespace WebApi;

public class ReceieverService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var _client = new ServiceBusClient(
            "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;");

        var _receiver = _client.CreateReceiver("queue.1");
        
        while(true)
        {
            var message = await _receiver.ReceiveMessageAsync(); 
            await Task.Delay(1000);
            Console.WriteLine($"Received message: {message.Body}");
        }
    }
}