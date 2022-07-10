using Gknzby.Kit.Management;

namespace Gknzby.Kit.UI
{
    public class UIComponent : IUIComponent
    {
        UIAction IUIComponent.ActionUI { get; set; }
        string IUIComponent.ActionUIValue { get; set; }

        void IUIComponent.SendActionToUIManager()
        {
            ManagerProvider.GetManager<IUIManager>().SendUIComponent(this);
        }
    }
}
