using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Kafka
{
    public interface IKafkaMessageBus<Tk, Tv>
    {
        Task PublishAsync(Tk key, Tv message);
    }
}
