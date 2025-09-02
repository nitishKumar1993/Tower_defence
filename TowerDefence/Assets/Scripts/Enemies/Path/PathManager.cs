using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public static class PathManager
    {
        private static Dictionary<string, Transform[]> paths = new();

        public static void RegisterPath(string id, Transform[] points)
        {
            if (!paths.ContainsKey(id))
            {
                paths[id] = points;
            }
        }

        public static Transform[] GetPath(string id)
        {
            if (paths.TryGetValue(id, out var path))
                return path;

            Debug.LogError($"Path ID not found: {id}");
            return null;
        }
    }
}