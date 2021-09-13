using UnityEngine;

[ExecuteInEditMode]
public static class OutputExtenshions
{
    public static void PrintLog(this string text)
    {
        Debug.Log(text);
    }
}

