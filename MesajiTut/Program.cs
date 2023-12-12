
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://lmfinsjz:RdqZIcDwJ1bnTfalX_07b1D_f-Y6CDI9@rat.rmq2.cloudamqp.com/lmfinsjz");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("mesaj-quyruq",true,false,false);

var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("mesaj-quyruq",true,consumer);


consumer.Received += Consumer_Received;
Console.ReadLine();

static void Consumer_Received(object sender,BasicDeliverEventArgs e)
{
    Console.WriteLine("Gelen mesaj :" + Encoding.UTF8.GetString(e.Body.ToArray()));
}