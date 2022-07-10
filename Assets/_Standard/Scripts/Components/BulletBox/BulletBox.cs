using UnityEngine;

namespace Gknzby.Kit.Components
{
    public class BulletBox : MonoBehaviour
    {
        [SerializeField] private BulletSpawner _spawner;
        [SerializeField] private BulletBoxGroup _bulletBoxGroup;

        private BulletBox _upBulletBox;
        private BulletBox _downBulletBox;

        private bool _stacked = false;
        private int _localFireRate = 1;

        private void OnTriggerEnter(Collider collider)
        {
            if (_stacked)
            {
                if (collider.gameObject.layer == LayerMask.GetMask("Obstacle"))
                {
                    _bulletBoxGroup.BoxHitObstacle(this);
                    return;
                }
            }
            else if (collider.gameObject.TryGetComponent(out BulletBox otherBox))
            {
                otherBox.GetStackPointAndFireRate(out Vector3 stackPoint, out int stackFireRate);
                Vector3 selfPoint = transform.position - transform.forward;
                selfPoint = GetComponent<Collider>().ClosestPoint(selfPoint);
                _bulletBoxGroup.StackGroup(selfPoint, stackPoint, stackFireRate);
            }
        }

        private void GetStackPointAndFireRate(out Vector3 stackPoint, out int stackFireRate)
        {
            if (_upBulletBox == null) //If causes low performance, manually locate top point
            {
                stackPoint = transform.position + transform.forward;
                stackPoint = GetComponent<Collider>().ClosestPoint(stackPoint);
                stackFireRate = _localFireRate;
                return;
            }
            else
            {
                _upBulletBox.GetStackPointAndFireRate(out stackPoint, out stackFireRate);
                return;
            }
        }

        public void DestroyBox(bool notifyUp)
        {
            _downBulletBox.UpDestroyed();
            if (notifyUp && _upBulletBox != null)
            {
                _upBulletBox.DownDestroyed();
            }

            _spawner.StopFire();
            Destroy(gameObject);
        }

        public void Stacked()
        {
            _stacked = true;
            CheckUpDown();
            if (_upBulletBox == null)
            {
                GetComponent<Collider>().isTrigger = true;
                _spawner.StartFire(_localFireRate);
            }
        }

        public void UpStacked(BulletBox upBulletBox)
        {
            _spawner.StopFire();
            _upBulletBox = upBulletBox;
        }

        public void DownStacked(BulletBox downBulletBox)
        {
            _downBulletBox = downBulletBox;
        }

        public void UpDestroyed()
        {
            _upBulletBox = null;
            _spawner.StartFire(_localFireRate);
        }

        public void DownDestroyed()
        {
            _downBulletBox = null;
            _bulletBoxGroup.DownBoxDestroyed();
        }

        public void UpdateStackFireRate(int stackFireRate)
        {
            _bulletBoxGroup.UpdateStackFireRate(stackFireRate);
        }

        public void UpdateLocalFireRate(int localFireRate, bool notifyUp)
        {
            _localFireRate = localFireRate;
            _spawner.ChangeFireRate(_localFireRate);
            if (notifyUp)
            {
                _upBulletBox.UpdateStackFireRate(_localFireRate);
            }
        }

        public bool HasDownBulletBox()
        {
            return _downBulletBox != null;
        }

        private void CheckUpDown()
        {
            Vector3 selfSize = GetComponent<Collider>().bounds.size;

            if (CheckNearBox(transform.forward, selfSize.z, ref _upBulletBox))//Down Check
            {
                _downBulletBox.UpStacked(this);
            }

            if (CheckNearBox(-transform.forward, selfSize.z, ref _downBulletBox)) //Up Check
            {
                _upBulletBox.DownStacked(this);
            }
        }

        private bool CheckNearBox(Vector3 direction, float distance, ref BulletBox bulletBox)
        {
            if (Physics.Raycast(origin: transform.position, direction: direction, out RaycastHit upHit, maxDistance: distance))
            {
                if (upHit.transform.CompareTag("BulletBox"))
                {
                    bulletBox = upHit.transform.GetComponent<BulletBox>();
                    return true;
                }
            }
            return false;
        }
    }
}