using UnityEngine;

namespace TowerDefence
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform m_point;

        private void Awake()
        {
            SpawnPointManager.RegisterSpawnPoint(this.gameObject.tag, m_point);
        }
    }
}