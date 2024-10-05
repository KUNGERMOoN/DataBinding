using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace MiniBinder
{
    public static class UIBindingManager
    {
        private static readonly List<IDisposable> Disposables = new();

        public static void AddDisposable(IDisposable disposable) => Disposables.Add(disposable);

        public static void RemoveDisposable(IDisposable disposable) => Disposables.Remove(disposable);

        public static void Dispose()
        {
            foreach (var disposable in new List<IDisposable>(Disposables))
                disposable.Dispose();
        }

        //Utilities to easily bind UI Elements to Bindables
        public static UIBindable<T> Bindable<T>(this BaseField<T> element)
            => UIBindable<T>.Get(element);

        public static void Bind<T>(this BaseField<T> element, Action<T> action)
            => UIBindable<T>.Get(element).Bind(action);

        public static void Bind<T>(this BaseField<T> element, Bindable<T> target, Processor<T> inputProcessor = null, Processor<T> outputProcessor = null)
            => UIBindable<T>.Get(element).Bind(target, inputProcessor, outputProcessor);

        public static void Unbind<T>(this BaseField<T> element, Action<T> action)
            => UIBindable<T>.Get(element).Unbind(action);

        public static void Unbind<T>(this BaseField<T> element, Bindable<T> target)
            => UIBindable<T>.Get(element).Unbind(target);
    }
}