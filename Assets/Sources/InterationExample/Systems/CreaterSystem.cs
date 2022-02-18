﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    /// <summary>
    /// 创建实体系统
    /// </summary>
    public class CreaterSystem : ReactiveSystem<InputEntity> {
        private GameContext _gameContext;
        public CreaterSystem(Contexts context) : base(context.input) {
            _gameContext = context.game;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach(InputEntity entity in entities) {
                var gameEntity = _gameContext.CreateEntity();
                gameEntity.AddInterationExampleSprite("pic");
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameEntity.AddInterationExamplePosition(worldPos);
            }
        }

        protected override bool Filter(InputEntity entity) {
            return entity.hasInterationExampleMouse 
                && entity.interationExampleMouse.mouse == MouseButton.LEFT
                && entity.interationExampleMouse.mouseEvent == MouseButtonEvent.DOWN;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.InterationExampleMouse);
        }
    }
}

