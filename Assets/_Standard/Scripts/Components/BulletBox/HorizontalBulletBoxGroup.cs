namespace Gknzby.Kit.Components
{
    public class HorizontalBulletBoxGroup : BulletBoxGroup
    {
        //If mide point hit, destroy all line //for now
        public override void BoxHitObstacle(BulletBox bulletBox)
        {
            int index = _bulletBoxes.IndexOf(bulletBox);
            if (_bulletBoxes.Count == 1
                || index != 0
                || index != _bulletBoxes.Count - 1)
            {
                DestroyAllBoxes();
                return;
            }

            _bulletBoxes[index].DestroyBox(true);
            _bulletBoxes.RemoveAt(index);
            if (!AnyBoxHasDownBox())
            {
                DestroyAllBoxes();
                return;
            }

            _groupFireRate -= 1;
            UpdateFireRate();
        }

        public override void DownBoxDestroyed()
        {
            if (!AnyBoxHasDownBox())
            {
                DestroyAllBoxes();
            }
        }

        private void DestroyAllBoxes()
        {
            for (int i = 0; i < _bulletBoxes.Count - 1; i++)
            {
                _bulletBoxes[i].DestroyBox(true);
            }

            _bulletBoxes.Clear();
            Destroy(gameObject);
        }

        private bool AnyBoxHasDownBox()
        {
            foreach (BulletBox bulletBox in _bulletBoxes)
            {
                if (bulletBox.HasDownBulletBox())
                {
                    return true;
                }
            }
            return false;
        }

        protected override void UpdateFireRate()
        {
            int localFireRate = _stackFireRate * _groupFireRate;

            for (int i = 0; i < _bulletBoxes.Count; i++)
            {
                _bulletBoxes[i].UpdateLocalFireRate(localFireRate, true);
            }
        }
    }
}