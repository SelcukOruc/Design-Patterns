using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPlayer : MonoBehaviour
{

    int currenttileIndex = 0;
    public int CurrentTileIndex => currenttileIndex;

    BoardTile currentTile = null;
    public void Move(BoardTile _targetTile)
    {
        Debug.Log("Current Tile Index : "+ CurrentTileIndex);

        currentTile = _targetTile;
        transform.position = _targetTile.transform.position;
        currenttileIndex = _targetTile.Index;

    }


}
