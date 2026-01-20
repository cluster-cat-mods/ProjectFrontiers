using UnityEngine;
using TMPro;

public class VariableUI : MonoBehaviour
{
    public TMP_Text VariableTextField;
    [SerializeField] private IntVariable Variable;
    public string TextBehindVariable;

    private void Update()
    {
        UpdateVariable(Variable.integer);
    }
    private void UpdateVariable(int PVariable)
    {
        Variable.integer = +PVariable;
        VariableTextField.text = Variable.integer + " " + TextBehindVariable;
    }


}
