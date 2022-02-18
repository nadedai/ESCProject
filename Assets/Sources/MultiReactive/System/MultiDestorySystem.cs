using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using MultiReactive;
namespace MultiReactive {
    /// <summary>
    /// 多上下文销毁系统
    /// </summary>
    public class MultiDestorySystem : MultiReactiveSystem<IDestorySystem, Contexts> {
        public MultiDestorySystem(Contexts contexts) : base(contexts) {
            Debug.Log("启动");
        }

        protected override void Execute(List<IDestorySystem> entities) {
            foreach(IDestorySystem  entity in entities) {
                Debug.Log("销毁" + entity.contextInfo.name);
                if (entity.hasMultiReactiveView) {
                    Object.Destroy(entity.multiReactiveView.viewTrans.gameObject);
                }
            }
        }

        protected override bool Filter(IDestorySystem entity) {
            Debug.Log("Filter");
            return entity.isMultiReactiveDestoryed;
        }

        protected override ICollector[] GetTrigger(Contexts contexts) {
            return new ICollector[] {
                contexts.game.CreateCollector(GameMatcher.MultiReactiveDestoryed),
                contexts.input.CreateCollector(InputMatcher.MultiReactiveDestoryed),
                contexts.ui.CreateCollector(UiMatcher.MultiReactiveDestoryed)
            };
        }
    }
    public interface IDestorySystem : IEntity, IMultiReactiveDestoryedEntity,IMultiReactiveViewEntity { }
    
}
public partial class GameEntity : IDestorySystem { }
public partial class InputEntity : IDestorySystem { }
public partial class UiEntity : IDestorySystem { }

