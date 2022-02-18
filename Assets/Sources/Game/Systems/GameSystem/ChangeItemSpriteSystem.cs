using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    /// <summary>
    /// 特殊元素响应系统
    /// </summary>
    public class ChangeItemSpriteSystem : ReactiveSystem<GameEntity> {
        public ChangeItemSpriteSystem(Contexts context) : base(context.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (GameEntity entity in entities) {
                string[] buffer = entity.gameLoadPrefab.path.Split('/');
                string itemName;
                if (buffer.Length == 2) {
                    itemName = buffer[1];
                }
                else continue;
                switch (entity.gameItemEffectState.state) {
                    case ItemEffctName.ELIMIMATE_SAME_COLOR:
                        itemName += Respath.AllPostfix;
                        break;
                    case ItemEffctName.ELIMIMATE_HORIZONTAL:
                        itemName += Respath.HorizontalPostfix;
                        break;
                    case ItemEffctName.ELIMIMATE_VARTICAL:
                        itemName += Respath.VertialPostfix;
                        break;
                    case ItemEffctName.EXPLODE:
                        itemName += Respath.ExplodePostfix;
                        break;
                }
                entity.ReplaceGameLoadSpite(itemName);

            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameItemEffectState && entity.gameItemEffectState.state != ItemEffctName.NONE;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameItemEffectState);
        }
        
    }
}
