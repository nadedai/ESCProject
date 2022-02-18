using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    /// <summary>
    /// 初始化所有数据类
    /// </summary>
    public class Modles {
        public static Modles Instance { private set; get; } = new Modles();
        /// <summary>
        /// 场景配置文件
        /// </summary>
        public DataModle DataModle { private set; get; }
        public void Init() {
            DataModle = LoadConfigService.Instance.LoadJson<DataModle>();
        }
    }
}
