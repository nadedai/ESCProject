using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class InputController : MonoBehaviour
{
    GameEntity a;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            a = Contexts.sharedInstance.game.CreateEntity();
        }
        if (Input.GetMouseButtonDown(1)) {
            a.isMultiReactiveDestoryed = true;
        }
    }
}
