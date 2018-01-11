using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用于保存每个炮塔的主要信息
/// </summary>
[System.Serializable]
public class TurretData
{
    public GameObject turretPrefab;//原始模型
    public GameObject turretPrefabUpgrade;//升级模型
    public int coast;//建造价格
    public int coastUpgraded;//升级价格
    public TurretType type;//炮塔类型
}

public enum TurretType
{
    StandardTurret,
    MissileTurret,
    LaserTurre
}

