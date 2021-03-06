using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    public class StartMoveSystem : ReactiveSystem<InputEntity> {
        private GameContext _gameContext;
        private IGroup<GameEntity> _moveGroup;
        public StartMoveSystem(Contexts context) : base(context.input) {
            _gameContext = context.game;
            _moveGroup = context.game.GetGroup(GameMatcher.InterationExampleView);
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach(InputEntity entity in entities) {
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                foreach(GameEntity gameEntity in _moveGroup) {
                    gameEntity.ReplaceInterationExampleMove(worldPos);
                }
            }
        }

        protected override bool Filter(InputEntity entity) {
            return entity.hasInterationExampleMouse
                && entity.interationExampleMouse.mouse == MouseButton.RIGHT
                && entity.interationExampleMouse.mouseEvent == MouseButtonEvent.DOWN;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.InterationExampleMouse);
        }
    }
}

