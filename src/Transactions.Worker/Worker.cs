using Confluent.Kafka;
using Newtonsoft.Json;
using Transactions.Core.Domain.Dtos;
using Transactions.Core.Shared.Extensions;
using Transactions.Core.Domain.Interfaces.Handlers;

namespace Transactions.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ISummaryHandle _handle;
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IConsumer<string, string> _consumer;

        public Worker(ISummaryHandle handle, IConfiguration configuration, ILogger<Worker> logger)
        {
            _logger = logger;
            _handle = handle;
            _configuration = configuration;

            ConsumerConfig config = new()
            {
                SaslMechanism = SaslMechanism.Plain,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                GroupId = _configuration["EventHub:GroupId"],
                SaslUsername = _configuration["EventHub:SaslUsername"],
                SaslPassword = _configuration["ConnectionsString:EventHub"],
                BootstrapServers = _configuration["EventHub:BootstrapServers"],
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe(_configuration["EventHub:Topic"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTime.Now.GetBrazilianTime());

                    ConsumeResult<string, string> response = _consumer.Consume(stoppingToken);
                    _logger.LogInformation($"[Message] [{response.Message.Value}]");

                    KafkaMessageDto message = JsonConvert.DeserializeObject<KafkaMessageDto>(response?.Message?.Value);
                    if (message?.Before is null && message?.After is not null)
                    {
                        await _handle.HandleAsync(message.After.Id, message.After.CustomerId);
                        continue;
                    }

                    _logger.LogInformation("Worker finished at: {time}", DateTime.Now.GetBrazilianTime());
                }
                catch (ConsumeException exception)
                {
                    _logger.LogError($"[ERROR] [{exception.Error.Reason}]");
                    continue;
                }
                catch (OperationCanceledException exception)
                {
                    _logger.LogError($"[ERROR] [{exception?.InnerException?.Message ?? exception?.Message}]");
                    continue;
                }
                catch (Exception exception)
                {
                    _logger.LogError($"[ERROR] [{exception?.InnerException?.Message ?? exception?.Message}]");
                    continue;
                }
            }
        }
    }
}