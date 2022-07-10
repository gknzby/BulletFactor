namespace Gknzby.Kit.Components
{
    public class VerticalBulletBoxGroup : BulletBoxGroup
    {
        public override void BoxHitObstacle(BulletBox bulletBox)
        {
            int index = _bulletBoxes.IndexOf(bulletBox);

            DestroyBoxes(index);

            if (_bulletBoxes.Count == 0)
            {
                _bulletBoxes.Clear();
                Destroy(gameObject);
                return;
            }

            _groupFireRate = _bulletBoxes.Count;
            UpdateFireRate();
            ResizeSelf();
        }

        public override void DownBoxDestroyed()
        {
            DestroyBoxes(0);

            _bulletBoxes.Clear();
            Destroy(gameObject);
        }

        private void DestroyBoxes(int startIndex)
        {
            int endIndex = _bulletBoxes.Count - 1;
            for (int i = startIndex; i < endIndex; i++) //Destroys until reach top
            {
                _bulletBoxes[i].DestroyBox(false);
            }
            _bulletBoxes[endIndex].DestroyBox(true); //Destroys top box

            _bulletBoxes.RemoveRange(startIndex, endIndex + 1);
        }

        protected override void UpdateFireRate()
        {
            int localFireRate = _stackFireRate + _groupFireRate;
            int count = _bulletBoxes.Count;

            for (int i = 0; i < count - 1; i++)
            {
                _bulletBoxes[i].UpdateLocalFireRate(localFireRate, false);
            }
            _bulletBoxes[count - 1].UpdateLocalFireRate(localFireRate, true);
        }
    }
}