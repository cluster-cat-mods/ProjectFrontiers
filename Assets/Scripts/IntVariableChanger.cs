using Unity.VisualScripting;
using UnityEngine;

public class IntvariableChanger : MonoBehaviour
{
    [SerializeField] private IntVariable intVariable;

    public void AddManual(int intP)
    {
        intVariable.integer += intP;
    }

    public void AddVariable(IntVariable intVariableP)
    {
        intVariable.integer += intVariableP.integer;
    }

    public void SetManual(int intP)
    {
        intVariable.integer = intP;
    }

    public void SetVariable(IntVariable intVariableP)
    {
        intVariable.integer = intVariableP.integer;
    }
}
