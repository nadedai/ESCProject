using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    /// <summary>
    /// 交换回滚
    /// </summary>
    public class ChangeBackSystem : ReactiveSystem<GameEntity> {
        public ChangeBackSystem(Contexts context) : base(context.game) {

        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(GameEntity entity in entities) {
                entity.ReplaceGameChange(ChangeState.CHANGE_BACK);
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameChange
                && entity.hasGameEliminate  
                && !entity.gameEliminate.canEliminate
                && entity.gameChange.changeState == ChangeState.CHANGE;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameEliminate);
        }
    }
}

