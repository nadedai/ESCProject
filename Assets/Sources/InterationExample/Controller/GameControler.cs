using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    public class GameControler : MonoBehaviour {
        private Systems _systems;
        private Contexts _contexts;
        // Start is called before the first frame update
        void Start() {
            _contexts = Contexts.sharedInstance;
            _systems = CreateSystems(_contexts);
        }

        // Update is called once per frame
        void Update() {
            _systems.Execute();
            _systems.Cleanup();
        }
        private Systems CreateSystems(Contexts contexts) {
            return new Feature("System").Add(new GameFeature(contexts))
                                        .Add(new InputFeature(contexts));
        }
    }
}

