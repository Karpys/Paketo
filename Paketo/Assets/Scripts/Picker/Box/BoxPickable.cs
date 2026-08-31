namespace KarpysDev.Scripts.Paketo
{
    using System;
    using KarpysUtils.TweenCustom;
    using UnityEngine;

    public class BoxPickable : MonoBehaviour,IPickable
    {
        [SerializeField] private Rigidbody m_Rigidbody = null;
        private Transform m_BaseParent = null;
        private bool m_InPick = false;
        private Action A_OnPick = null;

        public bool InPick => m_InPick;

        public Transform Root => transform;
        public Action OnPick
        {
            get => A_OnPick;
            set => A_OnPick = value;
        }

        private void Awake()
        {
            m_BaseParent = transform.parent;
        }

        public void Pick(IPicker picker)
        {
            OnPick?.Invoke();
            transform.parent = picker.Root;
            transform.DoLocalMove(Vector3.zero, 0.25f);
            transform.DoRotation(Vector3.zero,0.25f);
            m_Rigidbody.isKinematic = true;
            m_InPick = true;
        }

        public void Release(IPicker picker)
        {
            transform.parent = m_BaseParent;
            transform.DoKill();
            m_Rigidbody.isKinematic = false;
            m_InPick = false;
        }

        public void Place(IDeliverStation station)
        {
            m_Rigidbody.isKinematic = false;
            m_InPick = false;
        }
    }
}