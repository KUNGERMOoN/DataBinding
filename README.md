# MiniBinder
MiniBinder is a powerful data binding, change notification and state synchronization library for Unity. It's designed to simplify the process of connecting game View and Logic, especially in UI-heavy projects.

## Features
- Simplifies variable change detection via the `Bindable<>` class
- Supports complex binding structures, including many-to-many relationships and cyclical bindings
- Automatically detects and resolves recursive bindings
- Contains a built-in integration with Unity's UI Toolkit
- Includes various high-level utilities and extension methods to simplify the binding process

# Examples
### Detecting variable change
```csharp
public readonly BindableProperty<string> MyVariable = new("some text");

private void Start()
{
    //Run code on variable change
    MyVariable.Bind(MyFunction);

    Debug.Log(MyVariable); //\"some text"

    //Set the variable's value
    MyVariable.Value = "some other text"; //\"MyVariable has been changed to some other text"

}

void MyFunction(string value)
{
    Debug.Log($"MyVariable has been changed to \"{value}\"");
}
```

> You can think of the `BindableProperty<>` class as a box that contains the actual variable. As we don't want to replace the entire Bindable but only its value, we mark it as `readonly` and use its `.Value` property instead.
### Synchronizing two variables
```csharp
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
```
### Synchonizing a variable with UI
```csharp
public readonly BindableProperty<float> MyFloat = new(0);

void Awake()
{
    var slider = FindObjectOfType<UIDocument>()
        .rootVisualElement.Q<Slider>("mySlider");

    slider.Bind(MyFloat);
}

private void Update()
{
    MyFloat.Value = Mathf.Sin(Time.time);
    Debug.Log(MyFloat);
}
```
![gif](https://github.com/KUNGERMOoN/MiniBinder/blob/main/Assets/Docs/VariableUISynchonizationExample.gif?raw=true)
### Processing bound data
```csharp
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
```
### Complex binding structure
```csharp
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
```
![gif](https://github.com/KUNGERMOoN/MiniBinder/blob/main/Assets/Docs/ComplexBindingStructureExample.gif?raw=true)
