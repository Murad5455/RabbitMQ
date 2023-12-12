
using RabbitMQ.Client;
using System.Text;

for(int i = 0;i<10;i++)
{
    MessageSend();
}





static void MessageSend()
{
    var factory = new ConnectionFactory();
    factory.Uri = new Uri("amqps://lmfinsjz:RdqZIcDwJ1bnTfalX_07b1D_f-Y6CDI9@rat.rmq2.cloudamqp.com/lmfinsjz");

    using var connection = factory.CreateConnection();

    var channel = connection.CreateModel();

    channel.QueueDeclare("mesaj-quyruq", true, false, false);

    var messaj = "Deneme mesaj";
    var Body = Encoding.UTF8.GetBytes(messaj);

    channel.BasicPublish(string.Empty, "mesaj-quyruq", null, Body);

    Console.WriteLine("Salam");
    Console.ReadLine();
}