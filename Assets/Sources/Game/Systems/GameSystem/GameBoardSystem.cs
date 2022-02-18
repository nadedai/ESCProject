using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace Game {
    /// <summary>
    /// 游戏面板响应系统
    /// </summary>
    public class GameBoardSystem : ReactiveSystem<GameEntity>,IInitializeSystem {
        private IGroup<GameEntity> _itemGroup;
        
        public GameBoardSystem(Contexts contexts) : base(contexts.game) {
            _itemGroup = contexts.game.GetGroup(GameMatcher.GameGameBoardItem);
        }

        public void Initialize() {
            //CreateFromJson();
            CreateRandom();
        }

        private void CreateFromJson() {
            GameBoardComponent gameBoard = CreaterService.Instance.CreateGameBoard().gameGameBoard;
            var list = GetDataList();
            for(int row = 0;row < gameBoard.rows; row++) {
                for(int index = 0;index < list[row].Count; index++) {
                    CreaterService.Instance.CreateBall(list[row][index], index, row);
                }
            }
        }

        private void CreateRandom() {
            GameBoardComponent gameBoard = CreaterService.Instance.CreateGameBoard().gameGameBoard;
            CustomVector2 customVector2 = new CustomVector2();
            for (int x = 0; x < gameBoard.columns; x++) {
                for (int y = 0; y < gameBoard.rows; y++) {
                    customVector2.x = x;
                    customVector2.y = y;
                    //if (RandomNumBlocker()) CreaterService.Instance.CreateBlocker(customVector2);
                    //else CreaterService.Instance.CreateBallRandom(customVector2);
                    _ = RandomNumBlocker() ? CreaterService.Instance.CreateBlocker(customVector2) : CreaterService.Instance.CreateBallRandom(customVector2);
                }
            }
        }

        protected override void Execute(List<GameEntity> entities) {
            var gameBoard = entities.SingleEntity().gameGameBoard;
            foreach(Entity entity in entities) {
                //todo:消除超出游戏面板范围的元素
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameGameBoard;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameGameBoard);        }
        /// <summary>
        /// 生成障碍物概率
        /// </summary>
        /// <returns></returns>
        private bool RandomNumBlocker(){
            int num = Random.Range(0,10);
            if(num < 1) return true;
            return false;
        }

        private List<List<int>> GetDataList() {
            var modle = Modles.Instance.DataModle.Level[0] ;
            List<List<int>> list = new List<List<int>>();
            list.Add(modle.row_0);
            list.Add(modle.row_1);
            list.Add(modle.row_2);
            list.Add(modle.row_3);
            list.Add(modle.row_4);
            list.Add(modle.row_5);
            list.Add(modle.row_6);
            list.Add(modle.row_7);
            list.Add(modle.row_8);
            return list;
        }
    }
}

