using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private CommandUIManager commandUIManager;

    [SerializeField] private List<BoardTile> tiles = new List<BoardTile>();

    [SerializeField] private BoardPlayer player;
    Stack<ICommand> commands = new Stack<ICommand>();

    [ContextMenu("Roll Dice")]
    public void RollDice()
    {
        int result = Random.Range(1,6);
        int nextTileIndex = player.CurrentTileIndex + result;

        if (nextTileIndex > tiles.Count - 1)
            nextTileIndex -= (tiles.Count);

        BoardTile previousTile = tiles[player.CurrentTileIndex];
        BoardTile nextTile = tiles[nextTileIndex];
        
        Debug.Log("Roll Result: " + result);

        ICommand move = new MoveCommand(player, nextTile,previousTile);
        move.Execute();
        commands.Push(move);

        if (commandUIManager != null)
            commandUIManager.UpdateCommands(commands);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            RollDice();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            UndoMovment();
        
    }

    [ContextMenu("Undo Movment")]
    public void UndoMovment()
    {
        if (commands.Count > 0)
        {
            ICommand commandToUndo = commands.Pop();
            commandToUndo.Undo();

            if (commandUIManager != null)
                commandUIManager.UpdateCommands(commands);

        }
    }

}
