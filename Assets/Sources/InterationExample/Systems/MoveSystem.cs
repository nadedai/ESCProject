using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using DG.Tweening;
namespace InterationExample {
    /// <summary>
    /// 移动系统
    /// </summary>
    public class MoveSystem : ReactiveSystem<GameEntity> {
        public MoveSystem(Contexts context) : base(context.game) {
            
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (GameEntity entity in entities) {
                entity.interationExampleView.viewTrans.DOMove(entity.interationExampleMove.targetPos, 3);
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


