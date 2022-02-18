using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {
    public class JudgeSameColorSystem : ReactiveSystem<GameEntity> {
        public JudgeSameColorSystem(Contexts context) : base(context.game) {
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(GameEntity entity in entities) {
                if (IsMeetCondition(entity)) {
                    //Debug.Log("samecolor");
                    entity.isGameJudgeFormation = true;
                }
                else {
                    entity.ReplaceGameEliminate(false);
                }
            }
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameDetectionSameItem;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameDetectionSameItem);
        }

        private bool IsMeetCondition(GameEntity entity) {
            int left = entity.gameDetectionSameItem._leftEntities.Count;
            int right = entity.gameDetectionSameItem._rightEntities.Count;
            int up = entity.gameDetectionSameItem._upEntities.Count;
            int down = entity.gameDetectionSameItem._downEntities.Count;
            return left + right >= 2 || up + down >= 2;
        }
    }

}

