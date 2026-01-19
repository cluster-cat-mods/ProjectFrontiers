using UnityEngine;
using UnityEngine.Events;

public class IntVariableChecker : MonoBehaviour
{
    public IntVariable var1;
    public IntVariable var2;

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
            if (var1 == var2)
            {
                onCheckEvent.Invoke();
            }
        }
    }
}
