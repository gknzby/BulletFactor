using Gknzby.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Kit.Components
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float MaxReachDistance = 5f;
        [SerializeField] private float MovementSpeed = 1f;
        [SerializeField] private float SensorLength = 0.1f;

        private void OnEnable()
        {
            StartCoroutine(ForwardUntilReachOrHit());
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        private IEnumerator ForwardUntilReachOrHit()
        {
            float lerp = 0f;
            float reachTime = MaxReachDistance / MovementSpeed;
            Vector3 maxPoint = transform.position + transform.forward * MaxReachDistance;
            CarrierLine carrier = new CarrierLine(transform, transform.position, maxPoint);

            while(lerp < reachTime)
            {
                carrier.Lerp(lerp/reachTime);
                if(CheckObstacle())
                {
                    //Play effects;
                    gameObject.SetActive(false);
                    yield break;
                }
                yield return new WaitForFixedUpdate();
                lerp += Time.fixedDeltaTime;
                carrier.Lerp(lerp);
            }
            Management.ManagerProvider.GetManager<Management.IPoolingManager>().ReturnPoolObject("Bullet", gameObject);
            yield break;
        }
        private bool CheckObstacle()
        {
            LayerMask layerMask = LayerMask.GetMask("Obstacle");
            if(Physics.Raycast(transform.position,  transform.forward, out RaycastHit hit, SensorLength, layerMask))
            {
                Debug.Log("hit komutanim");
                //hit damageable?
                //Play effects
                return true;
            }
            return false;
        }

    } 
}
