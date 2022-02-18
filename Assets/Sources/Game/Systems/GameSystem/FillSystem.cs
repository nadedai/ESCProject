using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace Game {
    /// <summary>
    /// 填充系统
    /// </summary>
    public class FillSystem : ReactiveSystem<GameEntity> {
        private Contexts _contexts;
        public FillSystem(Contexts context) : base(context.game) {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities) {
            var gameBoard = _contexts.game.gameGameBoard;

            for (int colum = 0; colum < gameBoard.columns; colum++) {
                //获取最上层的坐标
                var pos = new CustomVector2(colum, gameBoard.rows + 1);
                //得到最小位置
                var rowPosMin = GetEmptyItemService.Instance.GetNextEmptyRow(pos);
                //填充
                for (int row = rowPosMin; row < gameBoard.rows; row++) {
                    var item = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(colum, row));
                    if(item.Count == 0) CreaterService.Instance.CreateBallRandom(new CustomVector2(colum, row));
                }
            }
        }

        protected override bool Filter(GameEntity entity) {
            return !entity.isGameGameBoardItem;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameGameBoardItem.Removed());
        }
    }
}

