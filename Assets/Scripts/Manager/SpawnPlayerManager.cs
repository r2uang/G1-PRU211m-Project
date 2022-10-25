using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    static bool isCreated = false;

    [SerializeField]
    private Transform pos;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        if (!isCreated)
        {
            Instantiate(playerPrefab, pos.position, Quaternion.identity);
            isCreated = true;
        }
        
    }
}
