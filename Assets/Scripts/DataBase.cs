using UnityEngine;
using UnityEngine.Events;

public class DataBase : MonoBehaviour
{
    [SerializeField] private IntVariable dataVar;
    [SerializeField] private IntVariable memVar;
    [SerializeField] private UnityEvent whileEvent;
    [SerializeField] private UnityEvent afterEvent;

    private float collectSpeed;

    private void Start()
    {
        collectSpeed = 1 + memVar.integer * 0.01f; 
    }

    public void CollectData()
    {
        while (dataVar.integer > 0)
        {
            dataVar.integer -= Mathf.RoundToInt(collectSpeed * Time.deltaTime);
            whileEvent.Invoke();
        }
        afterEvent.Invoke();
    }
}
