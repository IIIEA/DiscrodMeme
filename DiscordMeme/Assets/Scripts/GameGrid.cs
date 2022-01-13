using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _weight;
    [SerializeField] private float _gridCellSize = 1f;
    [SerializeField] private GridCell _cellTemplate;

    private GridCell[,] _grid;

    private void Start()
    {
        Create(_height, _weight);
    }

    private void Create(int height, int weight)
    {
        if (_cellTemplate == null)
            Debug.LogError("Cell template is empty");

        _grid = new GridCell[height, weight];

        for (int x = 0; x < _height; x++)
        {
            for (int z = 0; z < _weight; z++)
            {
                _grid[x, z] = Instantiate(_cellTemplate, new Vector3(x * _gridCellSize,0 ,z * _gridCellSize), Quaternion.identity);
                _grid[x, z].SetPosition(x, (int)transform.position.y, z);
                _grid[x, z].transform.parent = transform;
                _grid[x, z].gameObject.name = "X: " + x.ToString() + " " + "Z: " + z.ToString();
            }
        }
    }

    public Vector3 GetRandomSpawnPoint()
    {
        int randomPosX = Random.Range(0, _height);
        int randomPosZ = Random.Range(0, _weight);

        do
        {
            if (_grid[randomPosX, randomPosZ].IsOccupied)
            {
                randomPosX = Random.Range(0, _height);
                randomPosZ = Random.Range(0, _weight);
            }
        }
        while (_grid[randomPosX, randomPosZ].IsOccupied);

        _grid[randomPosX, randomPosZ].SetOccupied(true);

        return _grid[randomPosX, randomPosZ].GetPosition();
    }   
}
