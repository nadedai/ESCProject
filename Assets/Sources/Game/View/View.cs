using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;
namespace Game {
    /// <summary>
    /// 视图层基类
    /// </summary>
    public  class View : MonoBehaviour, IView,IGameDestoryListener {
        protected GameEntity _gameEntity;
        public virtual void Link(IEntity entity, IContext context) {
            if(entity is GameEntity) {
                _gameEntity = entity as GameEntity;
            }
            else {
                Debug.LogError("实体类型错误");
                return;
            }
            _gameEntity.AddGameDestoryListener(this);
            gameObject.Link(entity, context);

        }

        public virtual void OnGameDestory(GameEntity entity) {
            gameObject.Unlink();
        }
    }
}

