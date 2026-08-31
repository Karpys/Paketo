namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class ItemPicker : MonoBehaviour, IPicker
    {
        [SerializeField] private Transform m_Root = null;
        public Transform Root => m_Root;

        private IPickable m_CurrentPickable = null;

        public IPickable CurrentPickable => m_CurrentPickable;

        public void PickItem(IPickable pickable)
        {
            pickable.Pick(this);
            m_CurrentPickable = pickable;
        }

        public void ReleaseItem()
        {
            m_CurrentPickable.Release(this);
            ClearItem();
        }

        public void ClearItem()
        {
            m_CurrentPickable = null;
        }
    }
}