
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using DG.Tweening;
using Entitas.Unity;

namespace Game {
    /// <summary>
    /// 元素视图
    /// </summary>
    public class GameItemView : View, IGameItemIndexListener,IGameLoadSpiteListener {

        public override void Link(IEntity entity, IContext context) {
           
            if(entity is GameEntity) {
                
                base.Link(entity, context);
                _gameEntity.AddGameItemIndexListener(this);
                _gameEntity.AddGameLoadSpiteListener(this);
                transform.position = new Vector3(_gameEntity.gameItemIndex.index.x, Contexts.sharedInstance.game.gameGameBoard.rows);
            }
        }

        public void OnGameItemIndex(GameEntity entity, CustomVector2 index) {
            transform.DOMove(new Vector3(index.x, index.y), 0.3f).OnComplete(() => _gameEntity.isGameMoveComplete = true);
        }

        public override void OnGameDestory(GameEntity entity) {
            base.OnGameDestory(entity);
            float time = 0.5f;
            transform.DOScale(Vector3.one * 1.5f, time);
            transform.GetComponent<SpriteRenderer>().DOColor(Color.clear, time).OnComplete(()=> { Destroy(gameObject); } );
        }

        public void OnGameLoadSpite(GameEntity entity, string name) {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Respath.Spritepath + name);
        }
    }
}
