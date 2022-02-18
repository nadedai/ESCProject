using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

/// <summary>
/// 添加系统到框架
/// </summary>
public class AddGameSystem : Feature
{
    public AddGameSystem(Contexts contexts) : base("AddGameSystem") {
        Add(new LogSystem(contexts));
        Add(new InitSystem(contexts));
    }
}
