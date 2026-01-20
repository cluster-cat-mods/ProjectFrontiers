using UnityEngine;
using UnityEngine.Events;

public class IntVariableChecker : MonoBehaviour
{
    public IntVariable var1;
    public IntVariable var2;

    private float var1Value;
    private float var2Value;
    private void Start()
    {
        var1Value = var1.integer;
        var2Value = var2.integer;
    }
    private enum operators
    {
        equals,
        lower,
        higher
    } private operators currentOperator;

    public UnityEvent onCheckEvent;
    public void Check()
    {
        if (currentOperator == operators.equals)
        {
            if (var1Value == var2Value)
            {
                onCheckEvent.Invoke();
            }
        }
        if (currentOperator == operators.lower)
        {
            if (var1Value < var2Value)
            {
                onCheckEvent.Invoke();
            }
        }
        if (currentOperator == operators.higher)
        {
            if (var1Value > var2Value)
            {
                onCheckEvent.Invoke();
            }
        }
    }
}
