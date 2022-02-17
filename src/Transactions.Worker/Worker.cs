using Confluent.Kafka;

namespace Transactions.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumer<string, string> _consumer;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            ConsumerConfig config = new()
            {
                BootstrapServers = "",
                SaslUsername = "$ConnectionString",
                SaslPassword = "",
                GroupId = "transaction_consumer_group",
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe("transacion_server.dbo.transaction");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    var response = _consumer.Consume(stoppingToken);
                    _logger.LogInformation($"[Message] [{response.Message.Value}]");
                }
                catch (ConsumeException exception)
                {
                    _logger.LogError($"{exception.Error.Reason}");
                }
                catch (OperationCanceledException exception)
                {
                    _logger.LogError($"{exception?.InnerException?.Message ?? exception?.Message}");
                }
                catch (Exception exception)
                {
                    _logger.LogError($"{exception?.InnerException?.Message ?? exception?.Message}");
                }
            }
        }
    }
}