using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Kit.Management
{
    public interface IPoolingManager : IManager
    {
        bool GetPoolObject(string poolObjectName, out GameObject poolObject);
        bool ReturnPoolObject(string poolObjectName, GameObject poolObject);
    }
}