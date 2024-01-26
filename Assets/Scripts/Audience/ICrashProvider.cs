namespace Audience
{
    using UnityEngine;
    using Zenject;

    public interface ICrashProvider
    {
        bool HasCrash { get; }
    }
    
    public class CrashProvider : ICrashProvider, ITickable
    {
        public bool HasCrash { get; private set; }


        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HasCrash = !HasCrash;
            }
        }
    }
}