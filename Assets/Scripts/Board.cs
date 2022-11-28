using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Tile Properties")]
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private LevelConfigurationScriptable _levelConfig;
    
    public static Board instance;
    public Transform[,] _tiles = new Transform[,] { };

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _tiles = new Transform[_levelConfig.ColumnSize, _levelConfig.RowSize];
        Initialize();
    }
    
    private void Initialize()
    {
        for (int i = _levelConfig.RowSize-1; i >= 0; i--)
        {
            for (int j = _levelConfig.ColumnSize-1; j >= 0; j--)
            {
                Vector2 tilePos = new Vector2(j, i);
                GameObject tile = Instantiate(tilePrefab, tilePos, Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.name = j + ":" + i;
                _tiles[j, i] = tile.transform;

                // Make first row spawner and add match controller scripts to every column and every row.
                if (i == _levelConfig.RowSize-1)
                {
                    tile.AddComponent<DropSpawner>();
                    tile.GetComponent<DropSpawner>().SetSpawner(_levelConfig, j);

                    tile.AddComponent<MatchController>();
                }

                if (j == _levelConfig.ColumnSize - 1 && i != _levelConfig.RowSize - 1)
                {
                    tile.AddComponent<MatchController>();
                }
            }
        }
    }
}
