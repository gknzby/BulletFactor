using Gknzby.Kit.Management;
using Gknzby.Tools;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gknzby.Kit.Components
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform MinPositionTransform;
        [SerializeField] private Transform MaxPositionTransform;

        [SerializeField] private float HorizontalMovementSpeed = 1f;
        [SerializeField] private float ForwardMovementSpeed = 1f;
        [SerializeField] private bool RunBaby = true;

        private float _horizontalLerp = 0.500f;
        private float _forwardLerp = 0;
        private CarrierArea _carrierArea;

        private void GenerateCarrierArea()
        {
            Vector3 startPoint = MinPositionTransform.position;
            Vector3 destinationPoint = MaxPositionTransform.position;
            Vector3 forwardPoint = transform.position + transform.forward * ForwardMovementSpeed; 

            _carrierArea = new CarrierArea(transform, in startPoint, in forwardPoint, in destinationPoint, false, true);
        }

        private IEnumerator Running()
        {
            while(RunBaby)
            {
                yield return new WaitForFixedUpdate();
                _forwardLerp += Time.fixedDeltaTime * ForwardMovementSpeed;
                _carrierArea.ForwardLerp(ref _forwardLerp);
            }
        }

        private void OnEnable()
        {
            ManagerProvider.GetManager<IInputManager>()["HorizontalMove"].performed += MovePerformed;
            GenerateCarrierArea();
            StartCoroutine(Running());
        }
        private void OnDisable()
        {
            if(ManagerProvider.HasManager<IInputManager>())
            {
                ManagerProvider.GetManager<IInputManager>()["HorizontalMove"].performed -= MovePerformed;
            }
        }

        private void MovePerformed(InputAction.CallbackContext context)
        {
            float viewportDragDistance = context.ReadValue<float>(); 
            _horizontalLerp += (HorizontalMovementSpeed * viewportDragDistance) / Screen.width;
            _carrierArea.SideLerp(ref _horizontalLerp);
        }
    } 
}
