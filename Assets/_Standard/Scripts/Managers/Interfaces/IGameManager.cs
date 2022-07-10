namespace Gknzby.Kit.Management
{
    public interface IGameManager : IManager
    {
        void SendGameAction(GameAction action);
    }
}