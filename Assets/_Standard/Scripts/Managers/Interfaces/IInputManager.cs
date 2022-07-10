using Gknzby.Kit.Components;
using UnityEngine.InputSystem;

namespace Gknzby.Kit.Management
{
    public interface IInputManager : IManager
    {
        void StopSendingInputs();
        void StartSendingInputs();
        void CancelSendingInputs();
        InputAction this[string actionName] { get; }
    } 
}
