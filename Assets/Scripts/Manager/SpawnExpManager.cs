using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExpManager : MonoBehaviour
{

    const int SpawnBorderSize = 50;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    private float spawnExpTimer;

    ObjectPooler objectPooler;
    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        spawnExpTimer = 0.01f;
        objectPooler = ObjectPooler.Instance;
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

    }

    // Update is called once per frame
    void Update()
    {
        spawnExpTimer -= Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        InvokeRepeating("SpawnExp", spawnExpTimer, 0.01f);
    }

    private void SpawnExp()
    {
        if (spawnExpTimer <= 0)
        {
            Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),Random.Range(minSpawnY, maxSpawnY),-cam.transform.position.z);
            Vector3 worldLocation = cam.ScreenToWorldPoint(location);
            objectPooler.SpawnFromPool("Exp", worldLocation, Quaternion.identity);
            spawnExpTimer = 0.1f;
        }
        //if(objectPooler.pools[2].size == objectPooler.pools[2].maxSize)
        //{
        //    objectPooler.pools[2].size = 50;
        //}

    }
}
