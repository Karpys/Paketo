namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class CameraPointSelector : MonoBehaviour
    {
        [SerializeField] private Camera m_InputCamera = null;
        [SerializeField] private LayerMask m_Layer;
        [SerializeField] private float m_SelectionDistance = 1.0f;
        
        private ISelectable m_CurrentSelectable = null;
        private void Update()
        {
            TrySelect();
        }

        private void TrySelect()
        {
            Ray ray = m_InputCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
            RaycastHit hit;
            bool didHit = Physics.Raycast(ray, out hit, m_SelectionDistance, m_Layer);

            if (didHit)
            {
                ISelectable selectable = hit.transform.GetComponent<ISelectable>();
                
                if(selectable == null)
                    return;
                
                if(m_CurrentSelectable != null && m_CurrentSelectable != selectable)
                    m_CurrentSelectable.OnDeselect();
                
                selectable.OnSelect();
                m_CurrentSelectable = selectable;
            }
            else
            {
                if(m_CurrentSelectable == null)
                    return;
                
                m_CurrentSelectable.OnDeselect();
                m_CurrentSelectable = null;
            }
        }
    }
}