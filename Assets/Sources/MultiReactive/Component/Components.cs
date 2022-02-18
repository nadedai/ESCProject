using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
namespace MultiReactive {
    /// <summary>
    /// 多上下文销毁组件
    /// </summary>
    [Game, Input, Ui]
    public class DestoryedComponent : IComponent { }
    [Game, Input, Ui]
    public class ViewComponent : IComponent {
        
        public Transform viewTrans;
    }
    [Game, Event(EventTarget.Any)]
    public class NameComponet  : IComponent {
        [EntityIndex]
        public string name;
    }
}


