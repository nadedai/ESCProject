﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    /// <summary>
    /// 方向组件
    /// </summary>
    [Game]
    public class DirectionComponent : IComponent {
        /// <summary>
        /// 方向
        /// </summary>
        public float direction;
    }
}

