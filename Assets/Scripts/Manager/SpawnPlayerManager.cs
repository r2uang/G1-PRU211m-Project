using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    static bool isCreated = false;
    
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
            Instantiate(playerPrefab, new Vector3(0.8f, -14.9f, -10), Quaternion.identity);
            isCreated = true;
        }
        
    }
}
