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
        [SerializeField] private InputActionReference m_ReleaseAction = null;
        [SerializeField] [HasComponentOf(typeof(IPicker))] private Transform m_ItemPickerReference = null;
        
        [Header("Input")]
        [SerializeField] private Camera m_InputCamera = null;
        [SerializeField] private float m_SelectionDistance = 1.0f;
        [SerializeField] private LayerMask m_PickLayer;
        [SerializeField] private LayerMask m_DeliverLayer;

        private IPicker m_ItemPicker = null;
        private Action<bool> A_OnItemPick;

        public Action<bool> OnItemPick
        {
            get => A_OnItemPick;
            set => A_OnItemPick = value;
        }

        private void Awake()
        {
            m_ItemPicker = m_ItemPickerReference.GetComponent<IPicker>();
        }

        public void Update()
        {
            if (m_ClickAction.action.WasPressedThisFrame())
            {
                if (m_ItemPicker.CurrentPickable == null)
                {
                    TryPickItem();
                }
                else
                {
                    TryDeliverItem();
                }
            }
            
            if (m_ReleaseAction.action.WasPressedThisFrame())
                TryReleaseItem();
        }

        private void TryDeliverItem()
        {
            Ray ray = m_InputCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
            RaycastHit hit;
            bool didHit = Physics.Raycast(ray, out hit, m_SelectionDistance, m_DeliverLayer);
            
            if (didHit)
            {
                hit.transform.name.Log("Hit");
                IDeliverStation deliverStation = hit.transform.GetComponent<IDeliverStation>();
                
                if(deliverStation == null)
                    return;

                m_ItemPicker.CurrentPickable.Place(deliverStation);
                deliverStation.DeliverPickable(m_ItemPicker.CurrentPickable);
                m_ItemPicker.ClearItem();
                A_OnItemPick.Invoke(false);
            }
        }

        private void TryReleaseItem()
        {
            m_ItemPicker.ReleaseItem();
            A_OnItemPick.Invoke(false);
        }

        private void TryPickItem()
        {
            Ray ray = m_InputCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
            RaycastHit hit;
            bool didHit = Physics.Raycast(ray, out hit, m_SelectionDistance, m_PickLayer);
            
            if (didHit)
            {
                hit.transform.name.Log("Hit");
                IPickable pickable = hit.transform.GetComponent<IPickable>();
                
                if(pickable == null)
                    return;
                
                A_OnItemPick.Invoke(true);
                m_ItemPicker.PickItem(pickable);
            }
        }
    }
}