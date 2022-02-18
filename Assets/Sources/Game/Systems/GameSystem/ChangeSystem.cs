using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    /// <summary>
    /// 交换运动
    /// </summary>
    public class ChangeSystem : ReactiveSystem<GameEntity> {
        public ChangeSystem(Contexts contexts) : base(contexts.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            if(entities.Count == 2) {
                Change(entities[0], entities[1]);
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameChange
                && (entity.gameChange.changeState == ChangeState.START
                    || entity.gameChange.changeState == ChangeState.CHANGE_BACK);
                
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameChange);
        }
        private void Change(GameEntity one,GameEntity two) {
            var onePos = one.gameItemIndex.index;
            var twoPos = two.gameItemIndex.index;
            one.ReplaceGameItemIndex(twoPos);
            two.ReplaceGameItemIndex(onePos);
            SetChangeState(one);
            SetChangeState(two);
        }

        private void SetChangeState(GameEntity entity) {
            if (entity.gameChange.changeState == ChangeState.START) {
                entity.ReplaceGameChange(ChangeState.CHANGE);
            }
            else if(entity.gameChange.changeState == ChangeState.CHANGE_BACK) {
                entity.ReplaceGameChange(ChangeState.END);
            }
            
        }
    }
}

