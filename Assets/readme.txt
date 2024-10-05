# MiniBinder
MiniBinder is a powerful data binding, change notification and state synchronization library for Unity. It's designed to simplify the process of connecting game View and Logic, especially in UI-heavy projects.

## Features
- Simplifies variable change detection via the `Bindable<>` class
- Supports complex binding structures, including many-to-many relationships and cyclical bindings
- Automatically detects and resolves recursive bindings
- Contains a built-in integration with Unity's UI Toolkit
- Includes various high-level utilities and extension methods to simplify the binding process

# Examples
### Detect variable change
```csharp
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
```

> You can think of the `BindableProperty<>` class as a box that contains the actual variable. As we don't want to replace the entire Bindable but only its value, we mark it as `readonly` and use its `.Value` property instead.