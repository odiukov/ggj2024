namespace Core
{
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public interface IWindowOpener
    {
        T Create<T>() where T : MonoBehaviour, IWindow;
    }

    public interface IWindow
    {
        void Show();

        void Close();

        UniTask WaitUntilClosed();
    }
}