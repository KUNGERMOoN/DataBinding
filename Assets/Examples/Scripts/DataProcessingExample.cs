using UnityEngine;
using UnityEngine.UIElements;

namespace MiniBinder.Examples
{
    public class DataProcessingExample : MonoBehaviour
    {
        public readonly BindableProperty<string> Name = new("Bob");
        public readonly BindableProperty<string> Message = new();

        void Start()
        {
            Message.Bind(Name, inputProcessor: DataProcessor);
            Debug.Log(Message); //Hello, I'm Bob!

            Name.Value = "John";
            Debug.Log(Message); //Hello, I'm John!
        }

        string DataProcessor(string value)
        {
            return $"Hello, I'm {value}!";
        }
    }
}
