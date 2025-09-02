using UnityEngine;

namespace TowerDefence
{
    public class Path : MonoBehaviour
    {
        private void Awake()
        {
            PathManager.RegisterPath(this.gameObject.tag, GetComponentsInChildren<Transform>());
        }
    }
}