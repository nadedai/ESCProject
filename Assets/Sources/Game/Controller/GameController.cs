using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    public class GameController : MonoBehaviour {
        private Systems _system;
        void Awake() {
            var contexts = Contexts.sharedInstance;
            _system = GetSystems(contexts);
            new Services(contexts, transform);
            Modles.Instance.Init();
        }
        void Start() {
            _system.Initialize();
        }
        void Update() {

            //MMakeToast("hello");
            _system.Execute();
            _system.Cleanup();
        }
        private Systems GetSystems(Contexts contexts) {
            return new GameFeature(contexts)
                .Add(new GameEventSystems(contexts))
                .Add(new InputFeature(contexts));
        }


    }
}
