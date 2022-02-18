using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample{

    /// <summary>
    /// 坐标组件
    /// </summary>
    [Game]
    public class PositionComponent : IComponent {
        public Vector2 pos;
    }

}
