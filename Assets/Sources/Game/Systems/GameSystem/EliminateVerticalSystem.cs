using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;
namespace Game {
    public class EliminateVerticalSystem : ReactiveSystem<GameEntity> {
        private Contexts _contexts;
        public EliminateVerticalSystem(Contexts context) : base(context.game) {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities) {
            GameBoardComponent gameBoard = _contexts.game.gameGameBoard;
            GameEntity[] temp;
            foreach (GameEntity entity in entities) {
                for (int row = 0; row < gameBoard.rows; row++) {
                    temp = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(entity.gameItemIndex.index.x, row)).ToArray();
                    if (temp.Length == 1) {
                        temp[0].isGameDestory = true;
                    }
                }
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameItemEffectState
                && entity.gameItemEffectState.state == ItemEffctName.ELIMIMATE_VARTICAL;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameDestory);
        }
    }
}
