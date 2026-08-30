namespace KarpysDev.Scripts.Paketo
{
    using KarpysUtils;
    using KarpysUtils.TweenCustom;
    using UnityEngine;

    public class CharacterActionController : MonoBehaviour
    {
        [SerializeField] private CharacterInput m_CharacterInput = null;
        [SerializeField] private ItemPicker m_ItemPicker = null;

        [Header("References")]
        [SerializeField] private Transform m_LookRoot = null;

        private bool m_InLook = false;
        private void Awake()
        {
            m_CharacterInput.OnLookInput += OnLookInput;
        }

        private void OnLookInput()
        {
            if(m_ItemPicker.CurrentPickable == null)
                return;
            
            if (m_InLook)
            {
                m_ItemPicker.CurrentPickable.Root.DoLocalMove(Vector3.zero, 0.25f);
                m_ItemPicker.CurrentPickable.Root.DoRotation(Vector3.zero, 0.25f);
            }
            else
            {
                m_ItemPicker.CurrentPickable.Root.DoLocalMove(m_LookRoot.localPosition, 0.25f);
                m_ItemPicker.CurrentPickable.Root.DoRotation(new Vector3(-75,0,0), 0.25f);
            }

            m_InLook = !m_InLook;
        }
    }
}