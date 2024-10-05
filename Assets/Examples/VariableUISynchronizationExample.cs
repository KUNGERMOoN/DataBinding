using UnityEngine;
using UnityEngine.UIElements;

namespace MiniBinder.Examples
{
    public class VariableUISynchronizationExample : MonoBehaviour
    {
        public static BindableProperty<float> MyFloat = new(0);

        void Awake()
        {
            var slider = FindObjectOfType<UIDocument>().rootVisualElement.Q<Slider>("mySlider");

            slider.Bind(MyFloat);
        }

        private void Update()
        {
            MyFloat.Value = Mathf.Sin(Time.time);
            Debug.Log(MyFloat);
        }
    }
}
