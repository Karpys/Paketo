namespace KarpysDev.Scripts.Paketo
{
    using System;
    using KarpysUtils;
    using KarpysUtils.InterfaceUtils;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class ItemPickerSelector : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputActionReference m_ClickAction = null;
        [SerializeField] [HasComponentOf(typeof(IPicker))] private Transform m_ItemPickerReference = null;
        
        [Header("Input")]
        [SerializeField] private Camera m_InputCamera = null;
        [SerializeField] private float m_SelectionDistance = 1.0f;
        [SerializeField] private LayerMask m_LayerSelection;

        private IPicker m_ItemPicker = null;
        private void Awake()
        {
            m_ItemPicker = m_ItemPickerReference.GetComponent<IPicker>();
        }

        public void Update()
        {
            if (m_ClickAction.action.WasPressedThisFrame())
                TryPickItem();
        }

        private void TryPickItem()
        {
            Ray ray = m_InputCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
            RaycastHit hit;
            bool didHit = Physics.Raycast(ray, out hit, m_SelectionDistance, m_LayerSelection);
            
            if (didHit)
            {
                hit.transform.gameObject.Log("Item Touch");
                IPickable pickable = hit.transform.GetComponent<IPickable>();
                
                if(pickable == null)
                    return;
                
                m_ItemPicker.PickItem(pickable);
            }
        }
    }
}