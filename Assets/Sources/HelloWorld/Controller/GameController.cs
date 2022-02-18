using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class GameController : MonoBehaviour
{
    private Systems _systems;
    void Start()
    {
        var context = Contexts.sharedInstance;
        _systems = new Feature("Systems").Add(new AddGameSystem(context));
        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
