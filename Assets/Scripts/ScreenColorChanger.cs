using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class ScreenColorChanger : MonoBehaviour
{
    [SerializeField] private Color activeColor;
    [SerializeField] private Color deactiveColor;

    [SerializeField] private List<RawImage> screenIMGs;
    public void SetColor(int stateP)
    {
        foreach(RawImage img in screenIMGs)
        {
            if (stateP == 1)
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
