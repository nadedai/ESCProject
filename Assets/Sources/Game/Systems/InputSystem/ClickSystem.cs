using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    /// <summary>
    /// 点击响应系统
    /// </summary>
    public class ClickSystem : ReactiveSystem<InputEntity> {
        private Contexts _contexts;
        private ClickComponent _lastClickComponent;
        public ClickSystem(Contexts contexts) : base(contexts.input) {
            _contexts = contexts;
        }

        protected override void Execute(List<InputEntity> entities) {
            InputEntity input = entities.SingleEntity();
            var click = input.gameClick;
            var gameEntity = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(click.x, click.y));
            bool canMove = false;
            if(gameEntity != null) {
                if(gameEntity.Count == 1) {
                    canMove = gameEntity.SingleEntity().isGameMoveable;
                }
                else {
                    foreach(GameEntity e in gameEntity) {
                        Debug.Log(e);
                        Debug.Log(e.gameLoadPrefab.path);
                    }
                }
                
            }
            if (canMove) {
                if(_lastClickComponent == null) {
                    _lastClickComponent = click;
                }
                else {
                    if((click.x == _lastClickComponent.x - 1 && click.y == _lastClickComponent.y)
                       || (click.x == _lastClickComponent.x + 1&& click.y == _lastClickComponent.y)
                       || (click.x == _lastClickComponent.x&& click.y == _lastClickComponent.y-1)
                       || (click.x == _lastClickComponent.x&& click.y == _lastClickComponent.y+1)) {
                        ReplaceChange(click);
                        ReplaceChange(_lastClickComponent);
                        _lastClickComponent = null;
                    }
                    else {
                        _lastClickComponent = click;
                    }
                }
            }
        }

        protected override bool Filter(InputEntity entity) {
            return entity.hasGameClick;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.GameClick);
        }

        private void ReplaceChange(ClickComponent click) {
            var entitis = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(click.x,click.y));
            foreach(GameEntity entity in entitis) {
                entity.ReplaceGameChange(ChangeState.START);
            }
        }
    }
}

