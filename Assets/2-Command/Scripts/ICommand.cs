public interface ICommand
{
    public void Execute();
    public void Undo();
    public string CommandId();
}
