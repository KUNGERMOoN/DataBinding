using UnityEngine;

namespace MiniBinder.Examples
{
    public class VariableChangeExample : MonoBehaviour
    {
        public readonly BindableProperty<string> MyVariable = new("some text");

        private void Start()
        {
            //Run code on variable change
            MyVariable.Bind(MyFunction);

            Debug.Log(MyVariable); //<- prints "some text"

            //Set the variable's value
            MyVariable.Value = "some other text"; //<- prints "MyVariable has been changed to some other text"

        }

        void MyFunction(string value)
        {
            Debug.Log("MyVariable has been changed to " + value);
        }
    }
}