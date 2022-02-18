using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
namespace Game {
    [Input,Unique]
    public class ClickComponent : IComponent {
        public int x;
        public int y;
    }

    /// <summary>
    /// 滑动组件
    /// </summary>
    [Input, Unique]
    public class SlideComponent : IComponent {
        public CustomVector2 clickPos;
        public SlideDirection slideDirection;
    }
}
