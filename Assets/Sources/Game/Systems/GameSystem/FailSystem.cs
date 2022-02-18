using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;
namespace Game {
    /// <summary>
    /// 下落响应系统
    /// </summary>
    public class FailSystem : ReactiveSystem<GameEntity> {
        private Contexts _contexts;
        public FailSystem(Contexts context) : base(context.game) {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities) {
            //检查自身能否移动
            //能动 检查下面是否为空
            //空 下落
            var gameBoard = _contexts.game.gameGameBoard;
            for (int colum = 0; colum < gameBoard.columns; colum++) {
                for (int row = 0; row < gameBoard.rows; row++) {
                    var pos = new CustomVector2(colum, row);
                    var moveable = _contexts.game.GetEntitiesWithGameItemIndex(pos)
                        .Where(e => e.isGameMoveable).ToArray();
                    foreach (GameEntity entity in moveable) {
                        MoveDown(entity);
                    }
                }
            }

        }
        protected override bool Filter(GameEntity entity) {
            return !entity.isGameGameBoardItem;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameGameBoardItem.Removed());
        }

        private void MoveDown(GameEntity entity) {
            //检测本元素下面是否有空位
            //有 则移动到下面
            var nextRow = GetEmptyItemService.Instance.GetNextEmptyRow(entity.gameItemIndex.index);
            if(nextRow < entity.gameItemIndex.index.y) {
                entity.ReplaceGameItemIndex(new CustomVector2(entity.gameItemIndex.index.x, nextRow));
            } 
        }
    }
}

