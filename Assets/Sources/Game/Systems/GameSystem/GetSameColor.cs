using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game {
    public class GetSameColorSystem : ReactiveSystem<GameEntity> {
        private Contexts _contexts;

        public GetSameColorSystem(Contexts context) : base(context.game) {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var entity in entities) {
                entity.ReplaceGameDetectionSameItem(
                    JudgeLeft(entity),
                    JudgeRight(entity),
                    JudgeUP(entity),
                    JudgeDown(entity)
                    );
                entity.isGameGetSameColor = false;
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.isGameGetSameColor;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameGetSameColor);
        }

        private List<IEntity> JudgeLeft(GameEntity entity) {
            CustomVector2 pos = entity.gameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();
            for (int i = pos.x - 1; i >= 0; i--) {
                if (!AddSameColorItem(entity, i, pos.y, sameColorItems)) break;
            }
            return sameColorItems;
        }

        private List<IEntity> JudgeRight(GameEntity entity) {
            CustomVector2 pos = entity.gameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();
            for (int i = pos.x + 1; i < _contexts.game.gameGameBoard.columns; i++) {
                if (!AddSameColorItem(entity, i, pos.y, sameColorItems)) break;
            }
            return sameColorItems;
        }


        private List<IEntity> JudgeUP(GameEntity entity) {
            CustomVector2 pos = entity.gameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();
            for (int i = pos.y + 1; i < _contexts.game.gameGameBoard.rows; i++) {
                if (!AddSameColorItem(entity, pos.x, i, sameColorItems)) break;
            }
            return sameColorItems;
        }

        private List<IEntity> JudgeDown(GameEntity entity) {
            CustomVector2 pos = entity.gameItemIndex.index;
            List<IEntity> sameColorItems = new List<IEntity>();
            for (int i = pos.y - 1; i >= 0; i--) {
                if (!AddSameColorItem(entity, pos.x, i, sameColorItems)) break;
            }
            return sameColorItems;
        }

        private bool AddSameColorItem(GameEntity entity, int x, int y, List<IEntity> sameColorItems) {
            string colorName = entity.gameLoadPrefab.path;
            var returnValue = JudgeAddSameColor(colorName, x, y);
            if (!returnValue.Item1) {
                return false;
            }
            else {
                sameColorItems.Add(returnValue.Item2);
                return true;
            }
        }

        /// <summary>
        /// 判断相同颜色
        /// </summary>
        /// <param name="colorName"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Tuple<bool, GameEntity> JudgeAddSameColor(string colorName, int x, int y) {
            var array = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(x, y));
            if (array.Count == 1) {
                //Debug.Log("Enety唯一");
                var entity = array.SingleEntity();
                if (!entity.isGameMoveable) {
                    return new Tuple<bool, GameEntity>(false, entity);
                }

                if (entity.gameLoadPrefab.path == colorName) {
                    return new Tuple<bool, GameEntity>(true,entity);
                } 
                else return new Tuple<bool, GameEntity>(false, entity); ;
            }

            return new Tuple<bool, GameEntity>(false, null); 
        }
    }
}

