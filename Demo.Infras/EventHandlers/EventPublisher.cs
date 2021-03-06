using HBD.EfCore.Abstractions.Events;
using HBD.EfCore.Events.Handlers;
using System.Threading.Tasks;

namespace Demo.Infras.EventHandlers
{
    /// <summary>
    /// This will capture all event items after saved.
    /// Using this to push event to Service Bus or external api.
    /// </summary>
    public sealed class EventPublisher : IEventPublisher
    {
        #region Methods

        public Task PublishAsync(IEventItem domainEvent)
        {
            //TODO: implement your logic here
            return Task.CompletedTask;
        }

        #endregion Methods
    }
}
