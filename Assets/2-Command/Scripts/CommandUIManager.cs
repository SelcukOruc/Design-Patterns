using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandUIManager : MonoBehaviour
{
    [SerializeField] private CommandUIElement commandUIElementPrefab;
    List<CommandUIElement> commands = new List<CommandUIElement>();
    [SerializeField] private Transform content;
    public void UpdateCommands(Stack<ICommand> _commands)
    {
        foreach (var command in commands)
            Destroy(command.gameObject);
        commands.Clear();
        
        foreach (ICommand _command in _commands)
        {
            CommandUIElement commandUIElement = Instantiate(commandUIElementPrefab, content);
            commandUIElement.SetInfo(_command.CommandId());
            commands.Add(commandUIElement);
        }
    }

}
