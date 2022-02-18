using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
namespace InterationExample {
    /// <summary>
    /// 鼠标点击组件
    /// </summary>
    [Input,Unique]
    public class MouseComponent : IComponent {
        /// <summary>
        /// 点击的鼠标类型
        /// </summary>
        public MouseButton mouse;
        /// <summary>
        /// 鼠标事件
        /// </summary>
        public MouseButtonEvent mouseEvent;
    }
}

