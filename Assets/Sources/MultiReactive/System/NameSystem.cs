using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace MultiReactive {
    public class NameSystem : ReactiveSystem<GameEntity> {
        public NameSystem(IContext<GameEntity> context) : base(context) {
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(GameEntity entity in entities) {
                entity.AddMultiReactiveNameComponet("2");
            }
        }

        protected override bool Filter(GameEntity entity) {
            throw new System.NotImplementedException();
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            throw new System.NotImplementedException();
        }
    }
}

