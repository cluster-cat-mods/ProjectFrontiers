using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DataBase : MonoBehaviour
{
    [SerializeField] private IntVariable playerDataVar;
    [SerializeField] private IntVariable playerStorageVar;
    [SerializeField] private IntVariable playerMemVar;
    [SerializeField] private IntVariable dataBaseDataVar;
    [SerializeField] private IntVariable dataBaseStorageVar;
    [SerializeField] private IntVariable dataBaseMemVar;

    [SerializeField] private UnityEvent whileEvent;
    [SerializeField] private UnityEvent afterEvent;
    [SerializeField] private UnityEvent insertEvent;
    [SerializeField] private UnityEvent collectEvent;

    private float collectSpeed;
    private bool isProccesing = false;

    private void Start()
    {
        ResetIntVariable(playerDataVar);
        ResetIntVariable(playerStorageVar);
        ResetIntVariable(playerMemVar);
        ResetIntVariable(dataBaseDataVar);
        ResetIntVariable(dataBaseStorageVar);
        ResetIntVariable(dataBaseMemVar);
    }

    private void Update()
    {
        if (isProccesing)
        {
            Debug.Log("proccesing data");

            int amount = Mathf.Max(1, Mathf.RoundToInt(collectSpeed * Time.deltaTime));
            dataBaseStorageVar.integer -= amount;
            dataBaseDataVar.integer += amount;
            Mathf.Max(0, dataBaseStorageVar.integer);
            whileEvent.Invoke();
            if (dataBaseStorageVar.integer <= 0)
            {
                isProccesing = false;
                afterEvent.Invoke();
            }
        }
    }

    private void ResetIntVariable(IntVariable intVariableP)
    {
        intVariableP.integer = 0;
    }
    public void InsertData()
    {
        Debug.Log("inserted data");

        dataBaseMemVar.integer = playerMemVar.integer;
        playerMemVar.integer = 0;
        dataBaseStorageVar.integer = playerStorageVar.integer;
        playerStorageVar.integer = 0;
        collectSpeed = 1 + dataBaseMemVar.integer * 0.01f;
        insertEvent.Invoke();
    }

    public void StartDataProccesing()
    {
        if (!isProccesing)
        { 
            isProccesing = true;
        }
    }
    public void CollectData()
    {
        Debug.Log("collected data");

        playerDataVar.integer = dataBaseDataVar.integer;
        dataBaseDataVar.integer = 0;
        collectEvent.Invoke();
    }
}
