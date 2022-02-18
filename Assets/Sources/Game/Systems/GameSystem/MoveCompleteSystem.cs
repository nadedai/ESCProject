using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    /// <summary>
    /// 运动完成的响应系统
    /// </summary>
    public class MoveCompleteSystem : ReactiveSystem<GameEntity> {
        public MoveCompleteSystem(Contexts contexsts) : base(contexsts.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(var entity in entities) {
                entity.isGameGetSameColor = true;
                entity.isGameMoveComplete = false;
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.isGameMoveComplete;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameMoveComplete);
        }

    }
}

