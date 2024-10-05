using UnityEngine;
using UnityEngine.UIElements;

namespace MiniBinder.Examples
{
    public class ComplexBindingStructureExample : MonoBehaviour
    {
        public readonly BindableProperty<bool> IsPlaying = new();

        void Start()
        {
            var root = FindObjectOfType<UIDocument>().rootVisualElement;

            root.Q<Toggle>("play").Bind(IsPlaying);
            root.Q<Toggle>("pause").Bind(IsPlaying,
                inputProcessor: ReverseBool, outputProcessor: ReverseBool);
        }

        private void Update()
        {
            Debug.Log(IsPlaying);
        }

        bool ReverseBool(bool value) => !value;
    }
}
