using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 表示一波敌人的属性，下面的[System.Serializable]表示该类可以被序列化，只有可以序列化的对象才可以显示在Hierarchy面板中
/// </summary>
[System.Serializable]
public class Wave
{
    public GameObject prefab;//Enemy的预制体
    public int count;//敌人数量
    public float rate;//生成速率
}
