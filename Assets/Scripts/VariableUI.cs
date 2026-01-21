using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class VariableUI : MonoBehaviour
{
    private TMP_Text textField;

    private void Start()
    {
        textField = GetComponent<TMP_Text>();
    }
    public void SetTextField(IntVariable intVariableP)
    {
         textField.text= intVariableP.integer.ToString();
    }
    public void SetTextField(string stringP)
    {
        textField.text = stringP;
    }
}
