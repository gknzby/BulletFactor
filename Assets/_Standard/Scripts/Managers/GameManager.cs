namespace Gknzby.Kit.Management
{
    public enum GameAction
    {
        PauseGame,
        Lost,
        Win,
        Restart,
        LoadLevel,
        EndGame,
        ResumeGame,
        ExitGame
    }

    public class GameManager : AManager<IGameManager>, IGameManager
    {
        void IGameManager.SendGameAction(GameAction action)
        {
            switch (action)
            {
                case GameAction.PauseGame:
                    break;
                case GameAction.Lost:
                    break;
                case GameAction.Win:
                    break;
                case GameAction.Restart:
                    break;
                case GameAction.LoadLevel:
                    break;
                case GameAction.EndGame:
                    break;
                case GameAction.ResumeGame:
                    break;
                case GameAction.ExitGame:
                    break;
                default:
                    break;
            }
        }
    }
}
