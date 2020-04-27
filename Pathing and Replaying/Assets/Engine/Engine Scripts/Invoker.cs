using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private Command m_Command;
    public bool disableLog = false;

    public void SetCommand(Command command)
    {
        
        m_Command = command;
        
    }

    public void ExecuteCommmand()
    {
        if (!disableLog)
        {
            Command_Log.commands.Enqueue(m_Command);
        }
        m_Command.Execute();
    }

}
