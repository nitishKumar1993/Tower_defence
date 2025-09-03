using UnityEngine;

namespace TowerDefence
{
    public class PlacementGhost : MonoBehaviour
    {
        [SerializeField] private Renderer[] m_renderers;
        private MaterialPropertyBlock m_mpb;

        private void Awake()
        {
            m_mpb = new MaterialPropertyBlock();
            if (m_renderers.Length == 0)
            {
                m_renderers = GetComponentsInChildren<Renderer>();
            }
        }

        public void SetValid(bool isValid)
        {
            Color color = isValid ? Color.green : Color.red;
            foreach (var r in m_renderers)
            {
                r.GetPropertyBlock(m_mpb);
                m_mpb.SetColor("_Color", color);
                r.SetPropertyBlock(m_mpb);
            }
        }
    }
}