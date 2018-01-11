using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    public static Transform[] positions;

    void Awake()
    {
        positions=new Transform[transform.childCount];//通过transform组件的childCount属性获取子物体数量
        for (int i = 0; i < transform.childCount; i++)//通过小编遍历给positions数组赋值
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
