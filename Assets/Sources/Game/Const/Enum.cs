using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public enum SlideDirection {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    /// <summary>
    /// 交换状态
    /// </summary>
    public enum ChangeState {
        NULL,
        START,
        CHANGE,
        CHANGE_BACK,
        END
    }


    /// <summary>
    /// 特殊元素效果
    /// </summary>
    public enum ItemEffctName {
        NONE,
        /// <summary>
        /// 消除所有颜色的元素 5个及以上直线
        /// </summary>
        ELIMIMATE_SAME_COLOR,
        /// <summary>
        /// 消除行 4个元素横线
        /// </summary>
        ELIMIMATE_HORIZONTAL,
        /// <summary>
        /// 消除列 4个元素竖线
        /// </summary>
        ELIMIMATE_VARTICAL,
        /// <summary>
        /// 爆炸:消除9格 T字型
        /// </summary>
        EXPLODE
    }
}

