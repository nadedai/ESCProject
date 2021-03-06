//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.Eliminate gameEliminate { get { return (Game.Eliminate)GetComponent(GameComponentsLookup.GameEliminate); } }
    public bool hasGameEliminate { get { return HasComponent(GameComponentsLookup.GameEliminate); } }

    public void AddGameEliminate(bool newCanEliminate) {
        var index = GameComponentsLookup.GameEliminate;
        var component = (Game.Eliminate)CreateComponent(index, typeof(Game.Eliminate));
        component.canEliminate = newCanEliminate;
        AddComponent(index, component);
    }

    public void ReplaceGameEliminate(bool newCanEliminate) {
        var index = GameComponentsLookup.GameEliminate;
        var component = (Game.Eliminate)CreateComponent(index, typeof(Game.Eliminate));
        component.canEliminate = newCanEliminate;
        ReplaceComponent(index, component);
    }

    public void RemoveGameEliminate() {
        RemoveComponent(GameComponentsLookup.GameEliminate);
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

    static Entitas.IMatcher<GameEntity> _matcherGameEliminate;

    public static Entitas.IMatcher<GameEntity> GameEliminate {
        get {
            if (_matcherGameEliminate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameEliminate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameEliminate = matcher;
            }

            return _matcherGameEliminate;
        }
    }
}
