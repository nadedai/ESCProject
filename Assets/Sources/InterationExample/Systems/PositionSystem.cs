using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    public class PositionSystem : ReactiveSystem<GameEntity> {
        /// <summary>
        /// 位置系统
        /// </summary>
        /// <param name="context"></param>
        public PositionSystem(Contexts context) : base(context.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(GameEntity entity in entities) {
                entity.interationExampleView.viewTrans.position = entity.interationExamplePosition.pos;

            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasInterationExamplePosition && entity.hasInterationExampleView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.InterationExamplePosition);
        }
    }
}

