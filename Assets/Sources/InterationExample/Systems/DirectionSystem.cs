using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    /// <summary>
    /// 方向系统
    /// </summary>
    public class DirectionSystem : ReactiveSystem<GameEntity> {
        public DirectionSystem(Contexts context) : base(context.game) {
            
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (GameEntity entity in entities) {
                Transform view = entity.interationExampleView.viewTrans;
                Vector3 targetPos=  entity.interationExampleMove.targetPos;
                Vector3 direction = (targetPos - view.position).normalized;
                Quaternion angleOffset = Quaternion.FromToRotation(view.up,direction);
                view.rotation *= angleOffset;
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasInterationExampleMove
                && entity.isInterationExampleMoveComplete
                && entity.hasInterationExampleView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.InterationExampleMove);
        }
    }
}

