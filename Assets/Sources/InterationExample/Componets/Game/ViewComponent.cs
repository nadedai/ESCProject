using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace InterationExample {
    /// <summary>
    /// 视图层组件
    /// </summary>
    public class ViewComponent : IComponent {
        /// <summary>
        /// 视图层对象
        /// </summary>
        public Transform viewTrans;
    }
}
