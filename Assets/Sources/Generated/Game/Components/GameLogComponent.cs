//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LogComponent log { get { return (LogComponent)GetComponent(GameComponentsLookup.Log); } }
    public bool hasLog { get { return HasComponent(GameComponentsLookup.Log); } }

    public void AddLog(string newMsg) {
        var index = GameComponentsLookup.Log;
        var component = (LogComponent)CreateComponent(index, typeof(LogComponent));
        component.msg = newMsg;
        AddComponent(index, component);
    }

    public void ReplaceLog(string newMsg) {
        var index = GameComponentsLookup.Log;
        var component = (LogComponent)CreateComponent(index, typeof(LogComponent));
        component.msg = newMsg;
        ReplaceComponent(index, component);
    }

    public void RemoveLog() {
        RemoveComponent(GameComponentsLookup.Log);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLog;

    public static Entitas.IMatcher<GameEntity> Log {
        get {
            if (_matcherLog == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Log);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLog = matcher;
            }

            return _matcherLog;
        }
    }
}
