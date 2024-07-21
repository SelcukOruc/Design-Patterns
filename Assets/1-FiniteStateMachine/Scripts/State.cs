
public abstract class State 
{
    public abstract void OnStateEnter(CharacterStateManager _characterManager);
    public abstract void OnStateExit(CharacterStateManager _characterManager);
    public abstract void OnStateStay(CharacterStateManager _characterManager);
}
