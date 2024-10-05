using UnityEngine;

namespace MiniBinder.Examples
{
    public class StateSynchronizationExample : MonoBehaviour
    {
        public readonly BindableProperty<int> a = new(10);
        public readonly BindableProperty<int> b = new(20);

        private void Start()
        {
            //Bind a to b
            a.Bind(b);
            Debug.Log($"{a}, {b}"); //20, 20

            a.Value = 1337;
            Debug.Log(b); //1337

            b.Value = 14;
            Debug.Log(a); //14
        }
    }
}
