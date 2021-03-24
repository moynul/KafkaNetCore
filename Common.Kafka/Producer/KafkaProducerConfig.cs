using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Kafka.Producer
{
    public class KafkaProducerConfig<Tk, Tv> : ProducerConfig
    {
        public string Topic { get; set; }
    }
}
