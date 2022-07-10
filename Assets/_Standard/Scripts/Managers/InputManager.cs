using Gknzby.Kit.Components;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gknzby.Kit.Management
{
    public class InputManager : AManager<IInputManager>, IInputManager
    {
        private BasicMove _basicMove;

        InputAction IInputManager.this[string actionName]
        {
            get { return _basicMove.FindAction(actionName); }
        }

        private void Awake()
        {
            _basicMove = new BasicMove();
            _basicMove.Enable();
        }

        void IInputManager.CancelSendingInputs()
        {
            throw new System.NotImplementedException();
        }

        void IInputManager.StartSendingInputs()
        {
            throw new System.NotImplementedException();
        }

        void IInputManager.StopSendingInputs()
        {
            throw new System.NotImplementedException();
        }
    }
}
