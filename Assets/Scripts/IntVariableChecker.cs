using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;

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
        equals,
        lower,
        higher
    }
    [SerializeField] private int VariableToCompare;
    [SerializeField] private operators currentOperator;

    public bool Compare()
    {

        if (currentOperator == operators.equals)
        {
            if ((VariableToCheck.integer == IntVariableToCompare.integer) || (VariableToCheck.integer == VariableToCompare))
            {
                return true;
            }
            else return false;
        }
        else if (currentOperator == operators.lower)
        {
            if ((VariableToCheck.integer <= IntVariableToCompare.integer) || (VariableToCheck.integer <= VariableToCompare))
            {
                return true;
            }
            else return false;
        }
        else if (currentOperator == operators.higher)
        {
            if ((VariableToCheck.integer >= IntVariableToCompare.integer) || (VariableToCheck.integer >= VariableToCompare))
            {
                return true;
            }
            else return false;
        }
        else
        {
            Debug.LogWarning("Something went wrong");
            return false;
        }
    }
}

