namespace KarpysDev.Scripts.Paketo
{
    using System;
    using KarpysUtils.TweenCustom;
    using UnityEngine;

    public class BoxPickable : MonoBehaviour,IPickable
    {
        [SerializeField] private Rigidbody m_Rigidbody = null;
        private Transform m_BaseParent = null;

        private void Awake()
        {
            m_BaseParent = transform.parent;
        }

        public void Pick(IPicker picker)
        {
            transform.parent = picker.Root;
            transform.DoLocalMove(Vector3.zero, 0.25f);
            transform.DoLocalRotate(Vector3.zero,0.25f);
            m_Rigidbody.isKinematic = true;
        }

        public void Release(IPicker picker)
        {
            transform.parent = m_BaseParent;
            transform.DoKill();
            m_Rigidbody.isKinematic = false;
        }
    }
}