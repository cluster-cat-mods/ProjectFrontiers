using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntVariableChecker : MonoBehaviour
{
    public List<Comparison> comparisons;
    public UnityEvent onCheckEvent;

    private bool allTrue = true;
    public void check()
    {
        foreach (Comparison comparison in comparisons)
        {
            if(!comparison.Compare())
            {
                allTrue = false;
            }
        }
        if(allTrue) onCheckEvent.Invoke();
    }
}

[Serializable]
public class Comparison
{
    public IntVariable VariableToCheck;
    public IntVariable IntVariableToCompare;
    public enum operators
    {
        Equals,
        Lower,
        Higher,
        EqualsAndHigher,
        EqualsAndLower
    }
    [SerializeField] private operators currentOperator;

    public bool Compare()
    {
    switch(currentOperator)
        {
            case operators.Equals:
                if (VariableToCheck.integer == IntVariableToCompare.integer)
                {
                    return true;
                }
                else return false;
            case operators.Lower:
                if (VariableToCheck.integer < IntVariableToCompare.integer)
                {
                    return true;
                }
                else return false;
            case operators.Higher:
                if (VariableToCheck.integer > IntVariableToCompare.integer)
                {
                    return true;
                }
                else return false;
            case operators.EqualsAndLower:
                if (VariableToCheck.integer <= IntVariableToCompare.integer)
                {
                    return true;
                }
                else return false;
            case operators.EqualsAndHigher:
                if (VariableToCheck.integer >= IntVariableToCompare.integer)
                {
                    return true;
                }
                else return false;
            default:
                Debug.LogWarning("Something went wrong");
                return false;
        }

    }
}