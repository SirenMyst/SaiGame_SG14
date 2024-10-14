using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shootable", menuName = "SO/Shootable")]
public class ShootableObjectSO: ScriptableObject
{
    public string shootableName = "Shootable";
    public ObjectType objType;
    public int hpMax = 2;
    public List<ItemDropRate> dropList;
}
