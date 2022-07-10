namespace Gknzby.Kit.Management
{
    public class LevelManager : AManager<ILevelManager>, ILevelManager
    {
        int ILevelManager.LevelCount => -1;

        bool ILevelManager.LoadLevel(int index)
        {
            return false;
        }
    }
}