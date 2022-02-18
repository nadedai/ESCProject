using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace Game {
    /// <summary>
    /// 消除响应系统
    /// </summary>
    public class ElimininationSystem : ReactiveSystem<GameEntity> {
        public ElimininationSystem(Contexts context) : base(context.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            List<IEntity> sameEntities = GetSameEntity(entities);
            GameEntity temp;
            foreach(IEntity entity in sameEntities) {
                temp = entity as GameEntity;
                if (temp != null) temp.isGameDestory = true;
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameEliminate &&  entity.gameEliminate.canEliminate;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameEliminate);
        }


        private List<IEntity> GetSameEntity(List<GameEntity> entities) {
            List<IEntity> sameEntities = new List<IEntity>();
            foreach (GameEntity entity in entities) {
                //第一次生成特殊元素时 不消除
                if (entity.isGameFirstCreateEffect) {
                   // Debug.Log("判断第一次生成");
                    //sameEntities.Add(entity);
                    entity.isGameFirstCreateEffect = false;
                   // Debug.Log(entity.isGameFirstCreateEffect);
                }
                else sameEntities.Add(entity);
                int left = entity.gameDetectionSameItem._leftEntities.Count;
                int right = entity.gameDetectionSameItem._rightEntities.Count;
                int up = entity.gameDetectionSameItem._upEntities.Count;
                int down = entity.gameDetectionSameItem._downEntities.Count;

                if (left + right >= 2) {
                    sameEntities.AddRange(entity.gameDetectionSameItem._leftEntities);
                    sameEntities.AddRange(entity.gameDetectionSameItem._rightEntities);
                }
                if (up + down >= 2) {
                    sameEntities.AddRange(entity.gameDetectionSameItem._upEntities);
                    sameEntities.AddRange(entity.gameDetectionSameItem._downEntities);
                }
            }
            return sameEntities;
        }
    }
}
