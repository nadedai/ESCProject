using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;
namespace Game {
    public class EliminateExplodeSystem : ReactiveSystem<GameEntity> {
        private Contexts _contexts;
        public EliminateExplodeSystem(Contexts context) : base(context.game) {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities) {
            Debug.Log("explode");
            
            foreach (GameEntity entity in entities) {
                GameEntity[] temp;
                CustomVector2 pos = entity.gameItemIndex.index;


                for(int x = pos.x - 1;x <= pos.x + 1; x++) {
                    for(int y = pos.y - 1; y <= pos.y + 1; y++) {
                        if (x < 0 || y < 0) continue;
                        temp = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(x, y)).ToArray();
                        if(temp.Length == 1) {
                            temp[0].isGameDestory = true;
                        }
                    }
                }
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameItemEffectState
                && entity.gameItemEffectState.state == ItemEffctName.EXPLODE;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameDestory);
        }
    }

}
