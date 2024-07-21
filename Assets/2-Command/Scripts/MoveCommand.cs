using UnityEngine;

public class MoveCommand : ICommand
{
    BoardPlayer player;
    BoardTile nextTile;
    BoardTile previousTile;

    public MoveCommand(BoardPlayer _player, BoardTile _nextTile,BoardTile _previousTile)
    {
        player = _player;
        nextTile = _nextTile;
        previousTile = _previousTile;
    }

    public string CommandId()
    {
        return nextTile.Name;
    }

    public void Execute()
    {
        player.Move(nextTile);
    }
    public void Undo()
    {
        player.Move(previousTile);
    }
}