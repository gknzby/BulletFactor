using System.Collections.Generic;

namespace Gknzby.Kit.Management
{
    public class ManagerProvider
    {
        private static ManagerProvider _instance;
        private static ManagerProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerProvider();
                }
                return _instance;
            }
        }

        private Dictionary<System.Type, IManager> _managerCollection = new();

        public static void AddManager<T>(IManager manager)
            where T : IManager
        {
            if (Instance._managerCollection.ContainsKey(typeof(T)))
            {
                Instance._managerCollection[typeof(T)] = manager;
            }
            else
            {
                Instance._managerCollection.Add(typeof(T), manager);
            }
        }
        public static T GetManager<T>()
            where T : IManager
        {
            return Instance._managerCollection.ContainsKey(typeof(T)) ? (T)Instance._managerCollection[typeof(T)] : default;
        }
        public static void RemoveManager<T>()
            where T : IManager
        {
            if (Instance._managerCollection.ContainsKey(typeof(T)))
            {
                Instance._managerCollection.Remove(typeof(T));
            }
        }
        public static bool HasManager<T>()
            where T : IManager
        {
            return Instance._managerCollection.ContainsKey(typeof(T));
        }
    }
}