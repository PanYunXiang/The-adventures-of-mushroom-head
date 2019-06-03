using UnityEngine;

public class DebugTool
{
    private static DebugTool instacne;
    private DebugTool() { }

    private bool bDebug = true;

    public static DebugTool Instance
    {
        get
        {
            if (instacne == null)
            {
                instacne = new DebugTool();
            }
            return instacne;
        }
    }
    public void Log(object obj)
    {
        if (bDebug)
            Debug.Log(GetType() + "----->" + obj);
    }
    public void LogError(object obj)
    {
        if (bDebug)
            Debug.LogError(GetType() + "----->" + obj);
    }

    public void LogWarning(object obj)
    {
        if (bDebug)
            Debug.LogWarning(GetType() + "----->" + obj);
    }
}
