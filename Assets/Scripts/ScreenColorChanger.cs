using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class ScreenColorChanger : MonoBehaviour
{
    [SerializeField] private Color activeColor;
    [SerializeField] private Color deactiveColor;

    [SerializeField] private List<RawImage> screenIMGs;
    private enum state
    {
        active,
        deactive
    }
    private void SetColor(state stateP)
    {
        foreach(RawImage img in screenIMGs)
        {
            if (stateP == state.active)
            {
                img.color = activeColor;
            }
            else
            {
                img.color = deactiveColor;
            }
        }
    }

}
