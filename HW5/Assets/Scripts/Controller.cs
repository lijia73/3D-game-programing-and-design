using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public class Director : System.Object
    {
        private static Director _instance;

        public ISceneController currentSceneController { get; set; }
        public bool running { get; set; }

        public static Director GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Director();
            }

            return _instance;
        }
    }
    public interface ISceneController
    {
        void LoadResources();
    }
    public interface UserAction
    {
        void hit(Vector3 pos);
        void restart();
    }
    public enum SSActionEventType : int { Started, Completed }

    public interface ISSActionCallback
    {
        void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed);

    }

}
