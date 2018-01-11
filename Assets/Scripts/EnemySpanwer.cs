using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public static int  CountEnemyAlive;
    public Wave[] waves;
    public Transform startPos;
    public float waveRate;
    void Start()
    {
        StartCoroutine(SpanwEnemy());

    }
    /// <summary>
    /// 通过协程在一定时间间隔之内生成Enemy实例
    /// </summary>
    /// <returns></returns>
    IEnumerator SpanwEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)//逐波生成Enemy
            {
                GameObject.Instantiate(wave.prefab, startPos.position, Quaternion.identity);
                CountEnemyAlive++;
                yield return new WaitForSeconds(wave.rate);        
            }
            while (CountEnemyAlive>0)//如果上一波Enemy还没有全部被销毁，则直接返回
            {
                yield return 0;
            }
            yield return  new WaitForSeconds(waveRate);
        }
       
    }

}
