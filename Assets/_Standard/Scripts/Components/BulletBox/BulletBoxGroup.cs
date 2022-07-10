using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Kit.Components
{
    public abstract class BulletBoxGroup : MonoBehaviour
    {
        [SerializeField] protected List<BulletBox> _bulletBoxes = new();
        protected int _groupFireRate;
        protected int _stackFireRate;

        public void UpdateStackFireRate(int stackFireRate)
        {
            if (stackFireRate == _stackFireRate)
                return;
            _stackFireRate = stackFireRate;

            UpdateFireRate();
        }

        public void StackGroup(Vector3 selfPoint, Vector3 stackPoint, int stackFireRate)
        {
            Vector3 targetPoint = stackPoint + transform.position - selfPoint;
            transform.position = targetPoint;

            UpdateStackFireRate(stackFireRate);
            foreach (BulletBox bulletBox in _bulletBoxes)
            {
                bulletBox.Stacked();
            }
        }

        protected void ResizeSelf()
        {
            throw new System.NotImplementedException();
        }

        protected abstract void UpdateFireRate();

        public abstract void DownBoxDestroyed();

        public abstract void BoxHitObstacle(BulletBox bulletBox);

    }
}