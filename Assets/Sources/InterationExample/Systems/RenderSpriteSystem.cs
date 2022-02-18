using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    /// <summary>
    /// 添加图片
    /// </summary>
    public class RenderSpriteSystem : ReactiveSystem<GameEntity> {
        public RenderSpriteSystem(Contexts context) : base(context.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(GameEntity entity in entities) {
                Transform tans = entity.interationExampleView.viewTrans;
                SpriteRenderer sr = tans.GetComponent<SpriteRenderer>();
                if(sr == null) sr = tans.gameObject.AddComponent<SpriteRenderer>();
                //Debug.Log("ming"+entity.interationExampleSprite.spriteName);
                sr.sprite = Resources.Load<Sprite>(entity.interationExampleSprite.spriteName);    
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasInterationExampleSprite && entity.hasInterationExampleView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.InterationExampleSprite);
        }
    }
}
