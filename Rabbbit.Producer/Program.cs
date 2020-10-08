using Newtonsoft.Json;
using Rabbbit.Producer.Exchanges;
using RabbitMQ.Client;
using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Rabbbit.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using (var connection =factory.CreateConnection())
            {
                using (var chanel=connection.CreateModel())
                {
                    //QueueProducer.Publish(chanel);
                    FanoutExchangePublisher.Publish(chanel);
                }
            }

            Console.ReadKey();
        }
    }
}
