using UnityEngine;

namespace TowerDefence
{
    public class Path : MonoBehaviour
    {
        private void Awake()
        {
            Transform[] pathPoints = new Transform[this.transform.childCount];

            for (int i = 0; i < pathPoints.Length; i++) {
                pathPoints[i]  = transform.GetChild(i);
            }

            PathManager.RegisterPath(this.gameObject.tag, pathPoints);
        }
    }
}