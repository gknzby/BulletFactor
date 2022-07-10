using UnityEngine;

namespace Gknzby.Kit.Management
{
    public abstract class AManager<T> : MonoBehaviour, IManager
        where T : IManager
    {
        System.Type IManager.GetManagerType()
        {
            return typeof(T);
        }

        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            System.Type tType = typeof(T);
            System.Type thisType = this.GetType();

            Debug.Assert(tType != typeof(IManager), $"The generic type must be inheritance of IManager, not IManager. \nClass: {thisType.FullName}");
            Debug.Assert(tType.IsInterface, $"The generic type must be a interface. \nClass: {thisType.FullName}");

            System.Type findInterface = thisType.GetInterface(tType.Name);
            Debug.Assert(findInterface is not null, $"The generic type must be inherited by derivered class. \nClass: {thisType.FullName}");
#endif

            ManagerProvider.AddManager<T>(this);
        }

        protected virtual void OnDisable()
        {
            ManagerProvider.RemoveManager<T>();
        }
    }
}