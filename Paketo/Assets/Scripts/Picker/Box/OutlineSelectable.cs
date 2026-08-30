namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class OutlineSelectable : MonoBehaviour, ISelectable
    {
        [SerializeField] private Transform m_Outline = null;
        public void OnDeselect()
        {
            m_Outline.gameObject.SetActive(false);
        }

        public void OnSelect()
        {
            m_Outline.gameObject.SetActive(true);
        }
    }
}