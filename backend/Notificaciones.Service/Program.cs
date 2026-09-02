using Notificaciones.Service.Consumers;
using MassTransit;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(x =>
{
    // Registrar el consumidor
    x.AddConsumer<PrestamoCreadoConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        // Configurar endpoints automaticamente
        cfg.ConfigureEndpoints(context);
    });
});

var host = builder.Build();
host.Run();
