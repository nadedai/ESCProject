using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    public class DestorySystem : ICleanupSystem {
        private Contexts _contexts;
        private IGroup<GameEntity> _group;
        private List<GameEntity> _buffer= new List<GameEntity>();
        public DestorySystem(Contexts context) {
            _contexts = context;
            _group = _contexts.game.GetGroup(GameMatcher.GameDestory);
        }

        public void Cleanup() {
            
            foreach (var entity in _group.GetEntities(_buffer)) {
                entity.Destroy();
            }
        }

     
    }
}

