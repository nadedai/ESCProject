using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;


namespace Game {
    /// <summary>
    /// 游戏面板
    /// </summary>
    [Game, Unique]
    public class GameBoardComponent : IComponent {
        public int columns;
        public int rows;
    }

    /// <summary>
    /// 游戏界面元素
    /// </summary>
    [Game]
    public class GameBoardItemComponent : IComponent {
    }


    /// <summary>
    /// 游戏消除组件
    /// </summary>
    [Game, Event(EventTarget.Self)]
    public class DestoryComponent : IComponent {

    }
    /// <summary>
    /// 元素坐标
    /// </summary>
    [Game, Event(EventTarget.Self, Entitas.CodeGeneration.Attributes.EventType.Added, 1)]//数据变化响应
    public class ItemIndex : IComponent {
        [EntityIndex]
        public CustomVector2 index;//全局查找
    }

    /// <summary>
    /// 加载预制体组件
    /// </summary>
    [Game, Event(EventTarget.Any)]
    public class LoadPrefab : IComponent {
        public string path;
    }

    /// <summary>
    /// 元素可移动标签
    /// </summary>
    [Game]
    public class MoveableComponent : IComponent { }

    /// <summary>
    /// 交换状态标记组件
    /// </summary>
    public class ChangeComponent : IComponent {
        public ChangeState changeState;
    }

    /// <summary>
    /// 运动状态标记
    /// </summary>
    [Game]
    public class MoveCompleteComponent : IComponent { }


    /// <summary>
    /// 获取相同颜色元素的行为标记
    /// </summary>
    [Game]
    public class GetSameColorComponent : IComponent {
    }

    /// <summary>
    /// 保存相同颜色的数据
    /// </summary>
    [Game]
    public class DetectionSameItem : IComponent {
        public List<IEntity> _leftEntities;
        public List<IEntity> _rightEntities;
        public List<IEntity> _upEntities;
        public List<IEntity> _downEntities;
    }

    /// <summary>
    /// 判断队形是否生成特殊元素
    /// </summary>
    [Game]
    public class JudgeFormation : IComponent {

    }

    /// <summary>
    /// 标记是否能消除元素
    /// </summary>
    [Game]
    public class Eliminate : IComponent {
        public bool canEliminate;
    }

    /// <summary>
    /// 元素是否为特殊元素
    /// </summary>
    [Game]
    public class ItemEffectState : IComponent {
        public ItemEffctName state;
    }

    /// <summary>
    /// 加载图片组件
    /// </summary>
    [Game,Event(EventTarget.Self)]
    public class LoadSpite : IComponent {
        public string name;
    }

    [Game]
    public class FirstCreateEffect : IComponent {

    }

    [Game,Unique,Event(EventTarget.Any)]
    public class Score : IComponent {
        public int score;
    }
}


