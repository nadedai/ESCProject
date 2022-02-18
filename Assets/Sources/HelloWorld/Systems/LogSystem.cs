using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
/// <summary>
/// 打印消息系统
/// </summary>
public class LogSystem : ReactiveSystem<GameEntity> {

    public LogSystem(Contexts contexts) : base(contexts.game) {
       
    }
    protected override void Execute(List<GameEntity> entities) {
        foreach (GameEntity entity in entities) {
            Debug.Log(entity.log.msg);
        }
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasLog;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Log);//匹配器 
    }


}
