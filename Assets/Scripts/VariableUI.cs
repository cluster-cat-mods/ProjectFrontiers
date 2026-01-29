using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class VariableUI : MonoBehaviour
{
    [HideInInspector] public TMP_Text textField;

    private void Start()
    {
        textField = GetComponent<TMP_Text>();
    }
    public void SetTextField(IntVariable intVariableP)
    {
        textField.SetText(intVariableP.integer.ToString());
    }
    public void SetTextField(string stringP)
    {
        textField.text = stringP;
    }
}
