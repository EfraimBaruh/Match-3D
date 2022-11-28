using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Config", menuName = "ScriptableObjects/LevelConfigurationScriptable", order = 1)]
public class LevelConfigurationScriptable : ScriptableObject
{
    [Header("Board Properties")]
    public int RowSize;
    public int ColumnSize;
    [Header("Drop Samples")] 
    public List<GameObject> dropTypes = new List<GameObject>();
}
