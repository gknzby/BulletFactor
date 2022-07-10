using Gknzby.Kit.UI;

namespace Gknzby.Kit.Management
{
    public interface IUIManager : IManager
    {
        void SendUIComponent(IUIComponent uiComponent);
        void RegisterMenu(IUIMenu uiMenu);
        void UnregisterMenu(IUIMenu uiMenu);
    }
}
