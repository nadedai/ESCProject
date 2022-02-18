using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiReactive;
using Entitas;
using Entitas.Unity;
namespace MultiReactive {
    public class MultiViewSystem : MultiReactiveSystem<IViewSystem, Contexts> {
        private Dictionary<string, Transform> _parentDic = new Dictionary<string, Transform>();
        private Contexts _contexts;
        public MultiViewSystem(Contexts contexts) : base(contexts) {
            _contexts = contexts;
            foreach (var context in contexts.allContexts) {
                string name = context.contextInfo.name;
                _parentDic[name] = new GameObject(name + "ViewParent").transform;
                
            }
        }

        protected override void Execute(List<IViewSystem> entities) {
            foreach(IViewSystem entity in entities) {
                string name = entity.contextInfo.name;
                var go = new GameObject(name + "View");
                go.transform.SetParent(_parentDic[name]);
                entity.AddMultiReactiveView(go.transform);
                go.Link(entity,_contexts.getContextByName(name));
            }
        }

        protected override bool Filter(IViewSystem entity) {
            return !entity.hasMultiReactiveView;
        }

        protected override ICollector[] GetTrigger(Contexts contexts) {
            return new ICollector[] {
                contexts.game.CreateCollector(GameMatcher.MultiReactiveView),
                contexts.input.CreateCollector(InputMatcher.MultiReactiveView),
                contexts.ui.CreateCollector(UiMatcher.MultiReactiveView)
            };
        }
    }
    public interface IViewSystem : IEntity, IMultiReactiveDestoryedEntity, IMultiReactiveViewEntity { }
    public static class ContextExtention {
        private static readonly Dictionary<string, IContext> _contexgDic = new Dictionary<string, IContext>();
        public static IContext getContextByName(this Contexts contexts,string name) {
            InitDic(contexts);
            return _contexgDic[name];
        }
        private static void InitDic(Contexts contexts) {
            foreach(IContext context in contexts.allContexts) {
                _contexgDic[context.contextInfo.name] = context;
            }

        }
    }
}
public partial class GameEntity : IDestorySystem { }
public partial class InputEntity : IDestorySystem { }
public partial class UiEntity : IDestorySystem { }

