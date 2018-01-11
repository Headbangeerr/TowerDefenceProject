using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Transform[] positions;
    private int index = 0;
    void Start()
    {
        positions = WayPoints.positions;
    }
	// Update is called once per frame
	void Update ()
	{
	    Move();
	}


    /// <summary>
    /// 移动函数，利用Waypoint结点进行移动，用下一个目标节点减去自身所在位置即可获得一个方向向量，然后通过normailzed进行
    /// 标准化，通过公有变量speed调节不同种类的Enemy的速度。
    /// </summary>
    public void Move()
    {
        if(index==positions.Length) return;
        transform.Translate((positions[index].position - this.transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, positions[index].position) < 0.2f)//如果两点的距离小于0.2，则视为已经到达Waypoint
        {
            index++;
        }
        if (index == positions.Length)
        {
            ReachDestination();
        }
    }

    public void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
        Debug.Log(EnemySpanwer.CountEnemyAlive);
    }

    void OnDestroy()
    {
        Debug.Log("销毁啦");
        EnemySpanwer.CountEnemyAlive--;
    }
}
