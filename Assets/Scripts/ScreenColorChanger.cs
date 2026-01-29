using UnityEngine;
using UnityEngine.UI;

public class ScreenColorChanger : MonoBehaviour
{
    [SerializeField] private Color activeColor;
    [SerializeField] private Color deactiveColor;

    [SerializeField] private RawImage screenIMG;
    private enum state
    {
        active,
        deactive
    }
    private void SetColor(state stateP)
    {
        if (stateP == state.active)
        {
            screenIMG.color = activeColor;
        }
        else
        {
            screenIMG.color = deactiveColor;
        }
    }

}
