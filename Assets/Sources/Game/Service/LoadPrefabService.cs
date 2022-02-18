using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    public class LoadPrefabService : IGameLoadPrefabListener {
        private Contexts _contexts;
        private Transform _settleParent, _moveablParet;
        public static LoadPrefabService Instance { private set; get; } = new LoadPrefabService();

        public void Init(Contexts contexts,Transform gameController) {
            _contexts = contexts;
            contexts.game.CreateEntity().AddGameLoadPrefabListener(this);
            CreateSubParent(gameController);

        }
        private void CreateSubParent(Transform parent) {
            _settleParent = new GameObject("settle").transform;
            _settleParent.SetParent(parent);
            _moveablParet = new GameObject("moveable").transform;
            _moveablParet.SetParent(parent);
        }
        public void OnGameLoadPrefab(GameEntity entity, string path) {
            Transform temp = entity.isGameMoveable ? _moveablParet :_settleParent;
            GameObject go = Resources.Load<GameObject>(path);
            var view = Object.Instantiate(go,temp).GetComponent<IView>();
            view.Link(entity, _contexts.game);
        }
    }
}

