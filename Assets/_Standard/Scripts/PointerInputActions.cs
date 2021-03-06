//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_Standard/Scripts/PointerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gknzby.Kit
{
    public partial class @BasicMove : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @BasicMove()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PointerInputActions"",
    ""maps"": [
        {
            ""name"": ""SwerveRunner"",
            ""id"": ""eadce5f0-8f6c-4ffe-84af-ca6cccd5183b"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMove"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a844277e-2a70-4111-b30c-5a23f9650643"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""2bfd02c8-d23f-4d10-8f59-ba17c38f13bc"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""2fc7dcb8-1ccf-45dc-b726-b9c320a1bbbc"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""381d1e5a-413d-4aef-85a8-7dc2a1f44ec4"",
                    ""path"": ""<Pointer>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // SwerveRunner
            m_SwerveRunner = asset.FindActionMap("SwerveRunner", throwIfNotFound: true);
            m_SwerveRunner_HorizontalMove = m_SwerveRunner.FindAction("HorizontalMove", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // SwerveRunner
        private readonly InputActionMap m_SwerveRunner;
        private ISwerveRunnerActions m_SwerveRunnerActionsCallbackInterface;
        private readonly InputAction m_SwerveRunner_HorizontalMove;
        public struct SwerveRunnerActions
        {
            private @BasicMove m_Wrapper;
            public SwerveRunnerActions(@BasicMove wrapper) { m_Wrapper = wrapper; }
            public InputAction @HorizontalMove => m_Wrapper.m_SwerveRunner_HorizontalMove;
            public InputActionMap Get() { return m_Wrapper.m_SwerveRunner; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SwerveRunnerActions set) { return set.Get(); }
            public void SetCallbacks(ISwerveRunnerActions instance)
            {
                if (m_Wrapper.m_SwerveRunnerActionsCallbackInterface != null)
                {
                    @HorizontalMove.started -= m_Wrapper.m_SwerveRunnerActionsCallbackInterface.OnHorizontalMove;
                    @HorizontalMove.performed -= m_Wrapper.m_SwerveRunnerActionsCallbackInterface.OnHorizontalMove;
                    @HorizontalMove.canceled -= m_Wrapper.m_SwerveRunnerActionsCallbackInterface.OnHorizontalMove;
                }
                m_Wrapper.m_SwerveRunnerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @HorizontalMove.started += instance.OnHorizontalMove;
                    @HorizontalMove.performed += instance.OnHorizontalMove;
                    @HorizontalMove.canceled += instance.OnHorizontalMove;
                }
            }
        }
        public SwerveRunnerActions @SwerveRunner => new SwerveRunnerActions(this);
        public interface ISwerveRunnerActions
        {
            void OnHorizontalMove(InputAction.CallbackContext context);
        }
    }
}
