using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Kit.Management
{
    public class PoolingManager : AManager<IPoolingManager>, IPoolingManager
    {
        [System.Serializable]
        public class PoolData
        {
            public string Name;
            public GameObject PoolObjectPrefab;
            public int PoolSize;
            public Queue<GameObject> PassivePoolObjectQueue;
        }
        [SerializeField] private List<PoolData> _poolList = new();

        protected override void OnEnable()
        {
            base.OnEnable();
            Debug.Log("Pool Manager");
            GeneratePool();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            DestroyPool();
        }

        private void GeneratePool()
        {
            for (int i = 0; i < _poolList.Count; i++)
            {
                PoolData poolData = _poolList[i];
                poolData.PassivePoolObjectQueue = new Queue<GameObject>();
                for (int j = 0; j < poolData.PoolSize; j++)
                {
                    Debug.Assert(poolData.PoolObjectPrefab != null, $"There is no Prefab of {poolData.Name}");
                    GameObject poolObj = GameObject.Instantiate(poolData.PoolObjectPrefab, transform);
                    poolObj.name = poolData.Name;
                    poolObj.SetActive(false);
                    poolData.PassivePoolObjectQueue.Enqueue(poolObj);
                }
            }
        }

        private void DestroyPool()
        {
            foreach (PoolData poolData in _poolList)
            {
                foreach(GameObject pooledObject in poolData.PassivePoolObjectQueue)
                {
                    GameObject.Destroy(pooledObject);
                }
            }
        }

        private static int counter = 0;
        bool IPoolingManager.GetPoolObject(string poolObjectName, out GameObject pooledObject)
        {
            PoolData poolData = _poolList.Find(poolObj => poolObj.Name == poolObjectName);
            if (poolData is not null)
            {
                if(!poolData.PassivePoolObjectQueue.TryDequeue(out pooledObject))
                {
                    pooledObject = GameObject.Instantiate(poolData.PoolObjectPrefab, transform);
                    pooledObject.name = poolObjectName + "_pooled";
                    Debug.Log(counter++);
                }
                return true;
            }
            else
            {
                pooledObject = null;
                return false;
            }
        }

        bool IPoolingManager.ReturnPoolObject(string poolObjectName, GameObject returnedObject)
        {
            PoolData poolData = _poolList.Find(poolObj => poolObj.Name == poolObjectName);
            if (poolData is not null)
            {
                poolData.PassivePoolObjectQueue.Enqueue(returnedObject);
                return true;
            }
            else
            {
                GameObject.Destroy(returnedObject);
                return false;
            }
        }
    }
}
