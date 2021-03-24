﻿using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Kafka.Producer
{
    public class KafkaProducer<Tk, Tv> : IDisposable
    {
        private readonly IProducer<Tk, Tv> _producer;
        private readonly string _topic;

        public KafkaProducer(IOptions<KafkaProducerConfig<Tk, Tv>> topicOptions, IProducer<Tk, Tv> producer)
        {
            _topic = topicOptions.Value.Topic;
            _producer = producer;
        }

        public async Task ProduceAsync(Tk key, Tv value)
        {
            await _producer.ProduceAsync(_topic, new Message<Tk, Tv> { Key = key, Value = value });
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
