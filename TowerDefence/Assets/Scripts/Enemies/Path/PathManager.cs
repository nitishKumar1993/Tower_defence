using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public static class PathManager
    {
        private static Dictionary<string, Transform[]> m_paths = new();

        public static void RegisterPath(string id, Transform[] points)
        {
            if (!m_paths.ContainsKey(id))
            {
                m_paths[id] = points;
            }
        }

        public static Transform[] GetPath(string id)
        {
            if (m_paths.TryGetValue(id, out var path))
                return path;

            Debug.LogError($"Path ID not found: {id}");
            return null;
        }
    }
}