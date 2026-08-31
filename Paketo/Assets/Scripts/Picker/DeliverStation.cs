namespace KarpysDev.Scripts.Paketo
{
    using KarpysUtils.TweenCustom;
    using UnityEngine;

    public class DeliverStation : MonoBehaviour, IDeliverStation
    {
        [SerializeField] private Transform m_PlaceToDeliver = null;
        
        private IPickable m_CurrentPickable = null;
        public void DeliverPickable(IPickable pickable)
        {
            pickable.Root.parent = m_PlaceToDeliver;
            pickable.Root.DoLocalMove(Vector3.zero, 0.25f);
            m_CurrentPickable = pickable;
        }
    }
}