using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    #region FIELDS
    private List<Drop> _spawnedDrops = new List<Drop>();
    private LevelConfigurationScriptable _levelConfigurationScriptable;
    // spawners column id
    private int _columnID;
    // spawn initial temp array
    private List<int> latestSpawns = new List<int>();

    #endregion
    public void SetSpawner(LevelConfigurationScriptable levelConfigurationScriptable, int columnID)
    {
        _levelConfigurationScriptable = levelConfigurationScriptable;
        _columnID = columnID;
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        for (int i = _levelConfigurationScriptable.RowSize - 1; i >= 0; i--)
        {
            // Get random drop till its available to spawn.
            while (true)
            {
                int dropID = Utils.GetRandomDrop();
                
                // TODO: Edit this part to control if spawnable via scriptable object events.
                if (IsSpawnAble(dropID))
                {
                    GameObject drop = Instantiate(_levelConfigurationScriptable.dropTypes[dropID],
                        Board.instance._tiles[_columnID, i]);
                    
                    break;
                }
            }
            
            yield return new WaitForSeconds(0.2f);
        }
    }

    private bool IsSpawnAble(int dropType)
    {
        if (latestSpawns.Count == 0)
        {
            latestSpawns.Add(dropType);
            return true;
        }
        else if(latestSpawns.Count < GameConstants.minimumMatchSize)
        {
            if (latestSpawns.Contains(dropType))
            {
                latestSpawns.Add(dropType);
                return true;
            }
            else
            {
                latestSpawns.Clear();
                latestSpawns.Add(dropType);
                return true;
            }
        }
        else
        {
            return false;
        }

    }
}
