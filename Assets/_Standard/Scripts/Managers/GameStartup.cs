using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Kit.Management
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private List<GameObject> sceneManagers = new();

        private void Awake()
        {
            foreach (GameObject go in sceneManagers)
            {
                if(go.scene.name is null)
                {
                    GameObject.Instantiate(go, this.transform.parent);
                }
                else
                {
                    go.SetActive(true);
                }
            }

        }
    }
}
