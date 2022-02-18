using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class InitSystem : IInitializeSystem {
    private readonly GameContext _gameContext;
    public InitSystem(Contexts contexts) {
        _gameContext = contexts.game;
    }

    public void Initialize() {
        _gameContext.CreateEntity().AddLog("hello world");
    }
}
