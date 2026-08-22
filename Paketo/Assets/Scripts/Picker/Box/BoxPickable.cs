namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class BoxPickable : MonoBehaviour,IPickable
    {
        public void Pick(IPicker picker)
        {
            Debug.Log("The box is selected");            
        }

        public void Release(IPicker picker)
        {
        }
    }
}