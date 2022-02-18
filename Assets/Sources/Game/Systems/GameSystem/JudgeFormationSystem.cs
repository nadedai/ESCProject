using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    /// <summary>
    /// 判断是否满足满足队形
    /// </summary>
    public class JudgeFormationSystem : ReactiveSystem<GameEntity> {
        public JudgeFormationSystem(Contexts context) : base(context.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(GameEntity entity in entities) {
                if (JudgeItem(entity)) {
                    entity.isGameFirstCreateEffect = entity.isGameFirstCreateEffect ? false : true;
                    Debug.Log(entity.isGameFirstCreateEffect);
                }
                
                entity.ReplaceGameEliminate(true);
                entity.isGameJudgeFormation = false;
            }
        }

        /// <summary>
        /// 判断是否满足特殊元素要求
        /// </summary>
        /// <param name="entity"></param>
        private bool JudgeItem(GameEntity entity) {
                if (JudgeElimateAll(entity.gameDetectionSameItem)) {
                    entity.ReplaceGameItemEffectState(ItemEffctName.ELIMIMATE_SAME_COLOR);
                    return true;
                }
                else if (JudgeElimateHorizontal(entity.gameDetectionSameItem)) {
                    entity.ReplaceGameItemEffectState(ItemEffctName.ELIMIMATE_HORIZONTAL);
                    return true;
                }

                else if (JudgeElimateVertical(entity.gameDetectionSameItem)) {
                    entity.ReplaceGameItemEffectState(ItemEffctName.ELIMIMATE_VARTICAL);
                    return true;
                }

                else if (JudgeExplode(entity.gameDetectionSameItem)) {
                    entity.ReplaceGameItemEffectState(ItemEffctName.EXPLODE);
                    return true;
                }
            return false;



            
        }

        protected override bool Filter(GameEntity entity) {
            return entity.isGameJudgeFormation;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameJudgeFormation);
        }

        //判断是否5个连成直线
        private bool JudgeElimateAll(DetectionSameItem list) {
            return list._leftEntities.Count + list._rightEntities.Count >= 4
                || list._upEntities.Count + list._downEntities.Count >= 4;
        }

        //判断4个连成一行
        private bool JudgeElimateHorizontal(DetectionSameItem list) {
            return list._leftEntities.Count + list._rightEntities.Count == 3;
        }

        //判断4个连成一列
        private bool JudgeElimateVertical(DetectionSameItem list) {
            return list._upEntities.Count + list._downEntities.Count == 3;
        }

        //判断T型
        private bool JudgeExplode(DetectionSameItem list) {
            int countHor = list._leftEntities.Count + list._rightEntities.Count;
            int countVer = list._upEntities.Count + list._downEntities.Count;
            if (countHor >= 2 && countVer >= 2) return true;
            return false;
        }
    }
}

