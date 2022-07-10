using Gknzby.Kit.UI;
using System.Collections.Generic;
using UIMenuList = System.Collections.Generic.List<Gknzby.Kit.UI.IUIMenu>;

namespace Gknzby.Kit.Management
{
    public class UIManager : AManager<IUIManager>, IUIManager
    {
        private Dictionary<string, UIMenuList> menuListCollection = new();


        void IUIManager.RegisterMenu(IUIMenu uiMenu)
        {
            if(menuListCollection.ContainsKey(uiMenu.MenuName))
            {
                HideMenu(uiMenu.MenuName);
            }
            else
            {
                menuListCollection[uiMenu.MenuName] = new UIMenuList();
            }

            menuListCollection[uiMenu.MenuName].Add(uiMenu);
        }
        void IUIManager.UnregisterMenu(IUIMenu uiMenu)
        {
            UIMenuList menuList = menuListCollection[uiMenu.MenuName];
            if(menuList?.Remove(uiMenu) is true)
            {
                uiMenu.Visibility = false;
            }
        }

        void IUIManager.SendUIComponent(IUIComponent uiComponent)
        {
            throw new System.NotImplementedException();
        }

        private void SendUIAction(UIAction uiAction)
        {
            throw new System.NotImplementedException();
        }

        private void HideMenu(string menuName)
        {
            if (menuListCollection.TryGetValue(menuName, out UIMenuList menuList))
            {
                IUIMenu menu = menuList.Find(menu => menu.MenuName == menuName);

                if(menu is not null)
                {
                    menu.Visibility = false;
                }
            }
        }

        private void ShowMenu(string menuName)
        {
            if (menuListCollection.TryGetValue(menuName, out UIMenuList menuList))
            {
                IUIMenu menu = menuList.Find(menu => menu.MenuName == menuName);

                if (menu is not null)
                {
                    menu.Visibility = true;
                }
            }
        }
    }
}
