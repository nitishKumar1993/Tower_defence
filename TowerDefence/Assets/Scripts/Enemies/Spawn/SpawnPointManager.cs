using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public static class SpawnPointManager
    {
        private static Dictionary<string, Transform> points = new();

        public static void RegisterSpawnPoint(string id, Transform point)
        {
            if (!points.ContainsKey(id))
            {
                points[id] = point;
            }
        }

        public static Transform GetSpawnPoint(string id)
        {
            if (points.TryGetValue(id, out var path))
                return path;

            Debug.LogError($"Spawn ID not found: {id}");
            return null;
        }
    }
}