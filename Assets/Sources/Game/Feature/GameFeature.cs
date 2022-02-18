using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace Game {

    public class GameFeature : Feature {
        public GameFeature(Contexts contexts) {
            Add(new GameBoardSystem(contexts));
            //Add(new ChangeSystem(contexts));
            //Add(new MoveCompleteSystem(contexts));
            //Add(new GetSameColorSystem(contexts));
            //Add(new JudgeSameColorSystem(contexts));
            //Add(new ElimininationSystem(contexts));
            //Add(new ChangeBackSystem(contexts));
            //Add(new DestorySystem(contexts));
            //Add(new FailSystem(contexts));
            //Add(new FillSystem(contexts));
            //Add(new ChangeItemSpriteSystem(contexts));
            //Add(new JudgeFormationSystem(contexts));
            //Add(new EliminateSameColorSystem(contexts));
            //Add(new EliminateHorizontalSystem(contexts));
            //Add(new EliminateVerticalSystem(contexts));
            //Add(new EliminateExplodeSystem(contexts));
            //Add(new ScoreSystem(contexts));
        }
    }
}

