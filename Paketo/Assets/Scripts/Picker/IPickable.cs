namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public interface IPickable
    {
        public Transform Root { get; }
        public void Pick(IPicker picker);
        public void Release(IPicker picker);
    }
}