using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;
namespace Game {
    public class EliminateHorizontalSystem : ReactiveSystem<GameEntity> {
        private Contexts _contexts;
        public EliminateHorizontalSystem(Contexts context) : base(context.game) {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities) {
            var gameBoard = _contexts.game.gameGameBoard;
            GameEntity[] temp;
            foreach (GameEntity entity in entities) {
                for(int column  = 0;column < gameBoard.columns; column++) {
                    temp = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(column, entity.gameItemIndex.index.y)).ToArray();
                    if(temp.Length == 1) {
                        temp[0].isGameDestory = true;
                    }
                }
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameItemEffectState
                && entity.gameItemEffectState.state == ItemEffctName.ELIMIMATE_HORIZONTAL;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameDestory);
        }
    }
}

