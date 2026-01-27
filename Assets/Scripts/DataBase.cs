using UnityEngine;
using UnityEngine.Events;

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

    private void Start()
    {
        collectSpeed = 1 + dataBaseMemVar.integer * 0.01f; 
    }

    public void InsertData()
    {
        dataBaseMemVar.integer = playerMemVar.integer;
        playerMemVar.integer = 0;
        dataBaseStorageVar.integer = playerStorageVar.integer;
        playerStorageVar.integer = 0;
    }

    public void ProccesData()
    {
        while (dataBaseStorageVar.integer > 0)
        {
            dataBaseStorageVar.integer -= Mathf.RoundToInt(collectSpeed * Time.deltaTime);
            dataBaseDataVar.integer += Mathf.RoundToInt(collectSpeed * Time.deltaTime);
            whileEvent.Invoke();
        }
        afterEvent.Invoke();
    }

    public void CollectData()
    {
        playerDataVar.integer = dataBaseDataVar.integer;
        dataBaseDataVar.integer = 0;
    }
}
