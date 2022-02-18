using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Entitas;
namespace Game{

    /// <summary>
    /// 获取空节点服务
    /// </summary>
    public class GetEmptyItemService {
        public static GetEmptyItemService Instance {  get; private set; } = new GetEmptyItemService();
        private Contexts _contexts;
        public void Init(Contexts contexts) {
            _contexts = contexts;
        }
        public int GetNextEmptyRow(CustomVector2 pos) {
            int row = pos.y;
            for(int i = pos.y - 1;i >= 0; i--) {
                var eneity = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(pos.x, i)).ToArray();
                if (eneity.Length > 1) {
                    foreach(GameEntity e in eneity) {
                        Debug.Log(e.gameLoadPrefab.path) ;
                        Debug.Log("x" + e.gameItemIndex.index.x + "y" + e.gameItemIndex.index.y);
                    }
                }
                if(eneity.Length == 0) {
                    //检测为空 标记位置
                    row = i;
                }
                else {
                    //检测到不可移动物体 跳过
                    if (!eneity.Single().isGameMoveable ) {
                        continue;
                    }
                    //检测到可移动元素 停止循环
                    break;
                }
            }
            return row;
        }


    }
}

