using Gknzby.Kit.Management;
using Gknzby.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Kit.Components
{
    public class BulletSpawner : MonoBehaviour
    {
        [Header("Bullet Specs")]
        [SerializeField] private string BulletPrefabName = "Bullet";
        [SerializeField] private float MaxReachDistance = 5f;
        [SerializeField] private float MovementSpeed = 1f;
        [SerializeField] private float SensorLength = 0.1f;
        [SerializeField] private LayerMask _layerMask;

        private bool _canFire = false;
        private float _spawnCooldown = 1f;
        private IPoolingManager _poolingManager;
        private List<(Transform transform, CarrierLine carrier)> _firedBullets;
        private Vector3 _sensorDirection;

        private void OnEnable()
        {
            _poolingManager = ManagerProvider.GetManager<IPoolingManager>();
            _firedBullets = new List<(Transform transform, CarrierLine carrier)>();
        }

        public void StartFire(int fireRate)
        {
            _sensorDirection = transform.forward;
            _canFire = true;
            ChangeFireRate(fireRate);
            StopAllCoroutines();
            StartCoroutine(Tick());
        }

        public void StopFire()
        {
            _canFire = false;
        }

        public void ClearFire()
        {
            _canFire = false;
            StopAllCoroutines();

            foreach (var bullet in _firedBullets)
            {
                bullet.transform.gameObject.SetActive(false);
                _poolingManager.ReturnPoolObject(BulletPrefabName, bullet.transform.gameObject);
            }
            _firedBullets.Clear(); 
        }

        public void ChangeFireRate(int fireRate)
        {
            fireRate = fireRate < 1 ? 1 : fireRate;
            _spawnCooldown = 1f / fireRate;
        }

        private IEnumerator Tick()
        {
            float spawnTimer = 0f;
            float reachTime = MaxReachDistance / MovementSpeed;

            while (_canFire)
            {
                spawnTimer += Time.deltaTime;
                if (_spawnCooldown < spawnTimer)
                {
                    spawnTimer -= _spawnCooldown;
                    SpawnBullet();
                }
                for (int i = _firedBullets.Count - 1; -1 < i; i--)
                {
                    HitOrReach(reachTime, i);
                }
                yield return null;
            }

            //When fire session ended
            while (0 < _firedBullets.Count)
            {
                for (int i = _firedBullets.Count - 1; -1 < i; i--)
                {
                    HitOrReach(reachTime, i);
                }
                yield return null;
            }
        }

        private void HitOrReach(float reachTime, int i)
        {
            var bullet = _firedBullets[i];
            bullet.carrier.DeltaLerp(Time.deltaTime / reachTime, out bool isReached);

            if (Physics.Raycast(bullet.transform.position, _sensorDirection, out RaycastHit hit, SensorLength, _layerMask))
            {
                Debug.Log("hit komutanim");
                //hit damageable?
                //Play effects
            }
            else if (isReached)
            {
                _firedBullets.RemoveAt(i);
                bullet.transform.gameObject.SetActive(false);
                _poolingManager.ReturnPoolObject(BulletPrefabName, bullet.transform.gameObject);
            }
        }

        private void SpawnBullet()
        {
            if (_poolingManager.GetPoolObject(BulletPrefabName, out GameObject bulletObject))
            {
                Vector3 maxPoint = transform.position + _sensorDirection * MaxReachDistance;
                CarrierLine carrier = new(bulletObject.transform, transform.position, maxPoint);
                (Transform transform, CarrierLine carrier) bullet = (bulletObject.transform, carrier);
                bulletObject.SetActive(true);
                bullet.carrier.Lerp(0);
                _firedBullets.Add(bullet);
            }
        }
    }
}
