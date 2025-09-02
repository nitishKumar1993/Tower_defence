using UnityEngine;

namespace TowerDefence
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private string pathID; // e.g. "GroundPath1"

        private void Awake()
        {
            PathManager.RegisterPath(pathID, GetComponentsInChildren<Transform>());
        }
    }
}