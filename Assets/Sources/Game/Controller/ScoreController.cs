using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

namespace Game {
    public class ScoreController : MonoBehaviour, IGameScoreListener {
        private Text scoreText;
        void Start() {
            Contexts.sharedInstance.game.CreateEntity().AddGameScoreListener(this);
            scoreText = GetComponent<Text>();
        }
        public void OnGameScore(GameEntity entity, int score) {
            scoreText.text = score.ToString();
        }
    }
}
