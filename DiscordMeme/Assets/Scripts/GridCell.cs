using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private bool _isOccupied = false;

    public int PosX { get; private set; }
    public int PosY { get; private set; }
    public int PosZ { get; private set; }

    public bool IsOccupied => _isOccupied; 

    public void SetPosition(int x,int y, int z)
    {
        PosX = x;
        PosY = y;
        PosZ = z;
    }

    public Vector3Int GetPosition()
    {
        return new Vector3Int(PosX, PosY, PosZ);
    }

    public void SetOccupied(bool value)
    {
        _isOccupied = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            Debug.Log("Occupied");
        }
    }
}
