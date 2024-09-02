﻿using MassTransit;
using Warehouse.Contracts;

namespace Stock.Services
{
    public class ProductConsumer : IConsumer<ProductMessage>
    {
        private readonly ILogger<ProductConsumer> _logger;
        public ProductConsumer(ILogger<ProductConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<ProductMessage> context)
        {
            _logger.LogInformation(" [*] Message received Code: {code} ,Name: {name} ", context.Message.Code, context.Message.Name);
            return Task.CompletedTask;
        }
    }
}
