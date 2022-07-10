using System.Collections.Generic;
using Gknzby.Kit.Components;

namespace Gknzby.Kit.Management
{
    public class EventManager : AManager<IEventManager>, IEventManager
    {
        protected Dictionary<string, CommonDelegate> DelegateList = new();
        CommonDelegate IEventManager.this[System.Enum eventName]
        {
            get { return DelegateList.ContainsKey(eventName.ToString()) ? DelegateList[eventName.ToString()] : null; }
            set { DelegateList[eventName.ToString()] = value; }
        }
        CommonDelegate IEventManager.this[string eventName]
        {
            get { return DelegateList.ContainsKey(eventName) ? DelegateList[eventName] : null; }
            set { DelegateList[eventName] = value; }
        }
    }


}

