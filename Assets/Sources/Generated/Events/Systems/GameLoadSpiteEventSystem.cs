//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameLoadSpiteEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IGameLoadSpiteListener> _listenerBuffer;

    public GameLoadSpiteEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IGameLoadSpiteListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.GameLoadSpite)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasGameLoadSpite && entity.hasGameLoadSpiteListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.gameLoadSpite;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.gameLoadSpiteListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnGameLoadSpite(e, component.name);
            }
        }
    }
}
