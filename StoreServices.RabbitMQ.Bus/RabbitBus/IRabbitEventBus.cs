using StoreServices.RabbitMQ.Bus.Commands;
using StoreServices.RabbitMQ.Bus.Events;
using System.Threading.Tasks;

namespace StoreServices.RabbitMQ.Bus.RabbitBus
{
    public interface IRabbitEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Suscribe<T, TH>() where T : Event
                               where TH : IEventHandler<T>;
    }
}
