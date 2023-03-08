using UnityEngine;

// RESOURCE: https://www.youtube.com/watch?v=y2N_J391ptg

public class ToolTip : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        TooltipManager._instance.SetAndShowToolTip(message);
    }

    private void OnMouseExit()
    {
        TooltipManager._instance.HideToolTip();
    }
}
