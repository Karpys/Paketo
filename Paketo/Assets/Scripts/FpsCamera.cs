namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class FpsCamera : MonoBehaviour
    {
        [SerializeField] private Camera m_PlayerCamera = null;
        [SerializeField] private InputActionReference m_MouseInput = null;
        [SerializeField] private float m_MouseSensitivity = 0.5f;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            HandleMouseLook();
        }

        private float m_Pitch = 0;
        
        private void HandleMouseLook()
        {
            Vector2 lookInput = m_MouseInput.action.ReadValue<Vector2>();
            
            float mouseX = lookInput.x * m_MouseSensitivity;
            float mouseY = lookInput.y * m_MouseSensitivity;
 
            transform.Rotate(Vector3.up * mouseX);

            m_Pitch -= mouseY;
            m_Pitch = Mathf.Clamp(m_Pitch, -85f, 85f);
            m_PlayerCamera.transform.localRotation = Quaternion.Euler(m_Pitch, 0f, 0f);
        }
    }
}

