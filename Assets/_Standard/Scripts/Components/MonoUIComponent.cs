using Gknzby.Kit.Management;
using UnityEngine;

namespace Gknzby.Kit.UI
{
    public class MonoUIComponent : MonoBehaviour, IUIComponent
    {
        [SerializeField] private UIAction actionUI = UIAction.Unassigned;
        [SerializeField] private string uiActionValue = "UNASSIGNED";
        UIAction IUIComponent.ActionUI {
            get => actionUI;
            set => actionUI = value;
        }
        string IUIComponent.ActionUIValue
        {
            get => uiActionValue; 
            set => uiActionValue = value;
        }

        void IUIComponent.SendActionToUIManager()
        {
            ManagerProvider.GetManager<IUIManager>().SendUIComponent(this);
        }
    }
}