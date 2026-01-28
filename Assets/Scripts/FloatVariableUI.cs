using TMPro;
using UnityEngine;

public class FloatVariableUI : MonoBehaviour
{
    private TMP_Text textField;

    private void Start()
    {
        textField = GetComponent<TMP_Text>();
    }
    public void SetTextField(FloatVariable floatVariableP)
    {
        textField.text = floatVariableP.fl.ToString();
    }
    public void SetTextField(string stringP)
    {
        textField.text = stringP;
    }
}
