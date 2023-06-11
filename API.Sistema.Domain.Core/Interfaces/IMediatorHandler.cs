using API.Sistema.Domain.Core.Commands;
using API.Sistema.Domain.Core.Events;
using System.Threading.Tasks;

namespace API.Sistema.Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {

        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
