using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;
namespace Game{
    /// <summary>
    /// 特殊元素消除响应系统
    /// </summary>
    public class EliminateSameColorSystem : ReactiveSystem<GameEntity> {
        private Contexts _contexts;
        public EliminateSameColorSystem(Contexts context) : base(context.game) {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities) {
            var gameBoard = _contexts.game.gameGameBoard;
            foreach(GameEntity entity in entities) {
                var colorName = entity.gameLoadPrefab.path;
                GameEntity temp;
                for (int colum = 0; colum < gameBoard.columns; colum++) {
                    for (int row = 0; row < gameBoard.rows; row++) {
                        temp = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(colum, row))
                            .FirstOrDefault(u => u.gameLoadPrefab.path == colorName);
                        if (temp != null) temp.isGameDestory = true; 
                    }
                }
            }

        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameItemEffectState
                && entity.gameItemEffectState.state == ItemEffctName.ELIMIMATE_SAME_COLOR;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameDestory);
        }
    }

}
