using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Game {
    /// <summary>
    /// 加载配置服务
    /// </summary>
    public class LoadConfigService {
        public static LoadConfigService Instance { private set; get; } = new LoadConfigService();
        public T LoadJson<T>() where T : class{
            if (File.Exists(Respath.DataPath)) {
                string json = File.ReadAllText(Respath.DataPath);
                return JsonUtility.FromJson<T>(json);
            }
            return null;
        }
    }
}

