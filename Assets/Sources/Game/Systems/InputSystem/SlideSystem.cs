using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    /// <summary>
    /// 滑动响应系统
    /// </summary>
    public class SlideSystem : ReactiveSystem<InputEntity> {
        private Contexts _contexts;
        public SlideSystem(Contexts contexts) : base(contexts.input) {
            _contexts = contexts;
        }

        protected override void Execute(List<InputEntity> entities) {
            if (entities.Count == 1) {
                InputEntity entity = entities.SingleEntity();
                CustomVector2 pos = new CustomVector2(entity.gameSlide.clickPos.x, entity.gameSlide.clickPos.y);
                bool canMove = _contexts.game.GetEntitiesWithGameItemIndex(pos).SingleEntity().isGameMoveable;

                if (canMove) {
                    var nextPos = NextPos(entity);
                    _contexts.input.ReplaceGameClick(nextPos.x, nextPos.y);
                }
                //Debug.Log(entity.gameSlide.slideDirection);
            }
        }

        private CustomVector2 NextPos(InputEntity entity) {
            int x = entity.gameSlide.clickPos.x;
            int y = entity.gameSlide.clickPos.y;
            switch (entity.gameSlide.slideDirection) {
                case SlideDirection.LEFT:
                    x--;
                    break;
                case SlideDirection.RIGHT:
                    x++;
                    break;
                case SlideDirection.UP:
                    y++;
                    break;
                case SlideDirection.DOWN:
                    y--;
                    break;
            }
            x = LimtValue(x, 0, _contexts.game.gameGameBoard.columns - 1);
            y = LimtValue(y, 0, _contexts.game.gameGameBoard.rows - 1);
            return new CustomVector2(x,y);
        }
        //限制坐标范围
        private int LimtValue(int value, int min, int max) {
            if(value < min) {
                value = min;
            }

            else if(value > max) {
                value = max;
            }
            return value;
        }

        protected override bool Filter(InputEntity entity) {
            return entity.hasGameSlide;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.GameSlide);
        }
    }
}

