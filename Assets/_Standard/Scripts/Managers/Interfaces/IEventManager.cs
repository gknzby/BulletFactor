using Gknzby.Kit.Components;

namespace Gknzby.Kit.Management
{
    public interface IEventManager : IManager
    {
        CommonDelegate this[System.Enum eventName] { get; set; }
        CommonDelegate this[string eventName] { get; set; }
    }
}