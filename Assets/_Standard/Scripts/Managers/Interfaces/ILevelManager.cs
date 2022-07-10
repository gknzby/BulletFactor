namespace Gknzby.Kit.Management
{
    public interface ILevelManager : IManager
    {
        int LevelCount { get; }
        bool LoadLevel(int index);
    }
}