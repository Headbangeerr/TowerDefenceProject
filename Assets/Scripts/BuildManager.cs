using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class BuildManager : MonoBehaviour
{
    public Text totalMoneyText;

    public Animator moneyAnimator;
    //用于存储三种炮台的数据
    public TurretData laserTurretData;
    public TurretData missilrTurretData;
    public TurretData standardTurretData;

    private TurretData selectedTurretData;

    public int totalMoney = 1000;
	// Use this for initialization
	void Start ()
	{
        //获取剩余金钱UI
        totalMoneyText = GameObject.Find("TotalMoney").GetComponent<Text>();
	}
    /// <summary>
    /// 增加金钱并修改UI  
    /// </summary>
    /// <param name="money"></param>
    public void changeMoney(int money)
    {
        this.totalMoney += money;
        totalMoneyText.text = "￥" + totalMoney;
    }
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        //利用UI控件的EventSystem组件判断鼠标点击是否发生在UI控件上
            if (EventSystem.current.IsPointerOverGameObject()==false)
	        {
	            //建造炮台
	            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	            RaycastHit hit;
                //通过物理射线Ray对象来判断1000单位距离之内与"MapCube"层是否发生碰撞，并将碰撞信息传入hit对象中
                bool isCoilder = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                //如果发生碰撞，获取到点击到的MapCube物体
	            if (isCoilder)
	            {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    //如果该MapCube上没有炮台，则可以建造
	                if (mapCube.turret==null)
	                {
                        //如果剩余金额足够
	                    if (totalMoney >= selectedTurretData.coast)
	                    {
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                            changeMoney(-selectedTurretData.coast);
	                    }
	                    else//余额不足显示动画
	                    {
	                        moneyAnimator.SetTrigger("Flick");
	                    }
	                }
	                else
	                {
	                    
	                }
	            }
	        }   
	    }
	}
    /// <summary>
    /// 当三个ToggleGroup中的任一Toggle被点击，根据传入的name来判断是哪一个toggle被点击
    /// </summary>
    /// <param name="name"></param>
    public  void OnTurretItemSelected(String name)
    {
        switch (name)
        {
            case "LaserToggle":
                selectedTurretData = laserTurretData;
                break;
            case "MissleToggle":
                selectedTurretData = missilrTurretData;
                break;
            case "StandardToggle":
                selectedTurretData = standardTurretData;
                break;
        }
    }

}
