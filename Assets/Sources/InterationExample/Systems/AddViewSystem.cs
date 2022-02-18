using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
namespace InterationExample {
    /// <summary>
    /// 添加视图层系统
    /// </summary>
    
    public class AddViewSystem : ReactiveSystem<GameEntity> {
        private Transform _parent;
        private Contexts _contexts;
        public AddViewSystem(Contexts contexts) : base(contexts.game) {           
            _parent = new GameObject("ViewParent").transform;
            _contexts = contexts;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(GameEntity entity in entities) {
                GameObject go = new GameObject("View");
                go.transform.SetParent(_parent);
                go.Link(entity, _contexts.game);
                entity.AddInterationExampleView(go.transform);
                entity.isInterationExampleMoveComplete = true;
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasInterationExampleSprite && !entity.hasInterationExampleView;

        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.InterationExampleSprite);
        }
    }
}
