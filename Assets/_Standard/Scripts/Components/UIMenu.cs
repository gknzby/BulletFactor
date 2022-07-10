using Gknzby.Kit.Management;
using UnityEngine;

namespace Gknzby.Kit.UI
{
    public class UIMenu : MonoBehaviour, IUIMenu
    {
        [SerializeField] protected Transform MenuTransform;
        [SerializeField] protected string _menuName = "UNASSIGNED";
        string IUIMenu.MenuName => _menuName;

        private bool _visibility;
        bool IUIMenu.Visibility 
        { 
            get
            {
                return _visibility;
            }
            set
            {
                if (_visibility != value)
                {
                    _visibility = value;
                    ChangeVisibiliy(_visibility);
                }
            }
        }

        private void ChangeVisibiliy(bool isVisible)
        {
            this.gameObject.SetActive(isVisible);
        }
        protected virtual void Awake()
        {
            ManagerProvider.GetManager<IUIManager>().RegisterMenu(this);
        }
        protected virtual void OnDestroy()
        {
            ManagerProvider.GetManager<IUIManager>().UnregisterMenu(this);
        }
    }
}
