namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public interface IPickable
    {
        public void Pick(IPicker picker);
        public void Release(IPicker picker);
    }
}