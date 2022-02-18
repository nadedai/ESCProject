using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    public class CreaterService  {
        public static CreaterService Instance { private set; get; } = new CreaterService(); 


        private Contexts _contexts;
        public void Init(Contexts contexts) {
            _contexts = contexts;
        }
        /// <summary>
        /// 创建游戏面板
        /// </summary>
        public GameEntity CreateGameBoard() {
            GameEntity entity = _contexts.game.CreateEntity();
            entity.AddGameGameBoard(8, 9);
            return entity;
        }

        public GameEntity CreateBallRandom(CustomVector2 index) {
            var entity = _contexts.game.CreateEntity();
            entity.isGameGameBoardItem = true;
            entity.isGameMoveable = true;
            entity.AddGameItemIndex(index);
            entity.AddGameLoadPrefab(Respath.PrefabPath + RandomPathService.Randompath());
            entity.AddGameItemEffectState(ItemEffctName.NONE);
            return entity;
        }


        public GameEntity CreateBlocker(CustomVector2 index) {
            var entity = _contexts.game.CreateEntity();
            entity.isGameGameBoardItem = true;
            entity.isGameMoveable = false;
            entity.AddGameItemIndex(index);
            entity.AddGameLoadPrefab(Respath.BlockerPath);
            return entity;
        }

        /// <summary>
        /// 按照指定坐标生成元素
        /// </summary>
        /// <param name="nameIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GameEntity CreateBall(int nameIndex,int x,int y) {
            var entity = _contexts.game.CreateEntity();
            entity.isGameGameBoardItem = true;
            entity.isGameMoveable = true;
            entity.AddGameItemIndex(new CustomVector2(x,y));
            entity.AddGameLoadPrefab(Respath.PrefabPath + "Item" + nameIndex);
            entity.AddGameItemEffectState(ItemEffctName.NONE);
            return entity;
        }
    }
}


