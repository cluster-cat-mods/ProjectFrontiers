using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;

    public void SetSpawn(GameObject spawnPosP)
    {
        spawnPos = spawnPosP;
    }
    public void Respawn()
    {
        transform.position = spawnPos.transform.position;
        Debug.Log(spawnPos);
    }
}
