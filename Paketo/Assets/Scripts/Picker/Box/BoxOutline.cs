namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class BoxOutline : MonoBehaviour, ISelectable
    {
        [SerializeField] private BoxPickable m_BoxPickable = null;
        [SerializeField] private Transform m_Outline = null;

        private void Awake()
        {
            m_BoxPickable.OnPick += OnDeselect;
        }

        public void OnDeselect()
        {
            m_Outline.gameObject.SetActive(false);
        }

        public void OnSelect()
        {
            if(m_BoxPickable.InPick)
                return;
            m_Outline.gameObject.SetActive(true);
        }
    }
}