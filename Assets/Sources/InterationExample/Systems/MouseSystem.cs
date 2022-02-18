using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace InterationExample {
    /// <summary>
    /// 鼠标响应事件
    /// </summary>
    public class MouseSystem : IExecuteSystem ,IInitializeSystem{
        private InputEntity _inputEntity;
        private InputContext _contexts;
        public MouseSystem(Contexts contexts) {
            _contexts = contexts.input;
        }
        public void Execute() {
            if (Input.GetMouseButtonDown(0)) {
                _contexts.ReplaceInterationExampleMouse(MouseButton.LEFT,MouseButtonEvent.DOWN);
            }
            if (Input.GetMouseButtonDown(1)) {
                _contexts.ReplaceInterationExampleMouse(MouseButton.RIGHT, MouseButtonEvent.DOWN);
            }
        }

        public void Initialize() {
            _inputEntity = _contexts.interationExampleMouseEntity;
            
        }
    }
}

