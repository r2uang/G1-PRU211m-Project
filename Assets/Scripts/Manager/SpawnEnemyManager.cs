using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemyManager : MonoBehaviour
{
    //private ObjectPooler objectPooler;
    //public Transform player;            // The position that that camera will be following.
    //public float spawnTime;            // How long between each spawn.
    //public float spawnDistance;
    //public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    //private float nextSpawn = 0;

    const int SpawnBorderSize = 20;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    public float spawnTime;

    ObjectPooler objectPooler;
    [SerializeField]
    private Camera cam;

    void Start()
    {
        //objectPooler = ObjectPooler.Instance;
        //// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //nextSpawn = Time.time + spawnTime;

        objectPooler = ObjectPooler.Instance;
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //if (Time.time >= nextSpawn)
        //{
        //    Spawn();
        //    nextSpawn += spawnTime;
        //}
        InvokeRepeating("SpawnEnemy", spawnTime, 1f);
    }

    private void SpawnEnemy()
    {
        if (spawnTime <= 0)
        {
            Vector3 location = new Vector3(Random.Range(minSpawnX - 10, maxSpawnX + 10), Random.Range(minSpawnY - 5, maxSpawnY + 5), -cam.transform.position.z);
            Vector3 worldLocation = cam.ScreenToWorldPoint(location);
            foreach (var pool in objectPooler.poolDictionary)
            {
                if (!pool.Key.Equals("Exp"))
                {
                    objectPooler.SpawnFromPool(pool.Key, worldLocation, Quaternion.identity);
                }
            }
            objectPooler.SpawnFromPool("Exp", worldLocation, Quaternion.identity);
            spawnTime = 0.75f;
        }
        //if(objectPooler.pools[2].size == objectPooler.pools[2].maxSize)
        //{
        //    objectPooler.pools[2].size = 50;
        //}

    }

    //void Spawn(int count = 1)
    //{
    //    // collect the children that are close.
    //    List<Transform> near = new List<Transform>();
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        Transform spawnPoint = transform.GetChild(i);
    //        if (Vector3.Distance(player.transform.position, spawnPoint.position) <= spawnDistance)
    //        {
    //            near.Add(spawnPoint);
    //        }
    //    }


    //    if (near.Count > 0)
    //    {
    //        // create a new list here.... same as line 29, but call the variable something else.
    //        List<Transform> pointsToSpawn = new List<Transform>();

    //        // loop from 0 to <count here..... same as line 30 in the code you just had. {
    //        // make sure you include the below lines....
    //        for (int i = 0; i < count; i++)
    //        {
    //            // Find a random index between zero and one less than the number of spawn points.
    //            int spawnPointIndex = Random.Range(0, near.Count);

    //            // add near[spawnPointIndex] to the new list // same as line 35
    //            pointsToSpawn.Add(near[spawnPointIndex]);

    //            // remove spawnPointIndex from near // new line: near.RemoveAt(spawnPointIndex);
    //            near.RemoveAt(spawnPointIndex);

    //            // if we dont have any more points. break... // new line: Break;
    //            if (near.Count == 0) break;
    //            // end the loop... }
    //        }

    //        // loop through each of your new variable.... new line: foreach(Transform spawnPoint in newVariableName){
    //        foreach (var pool in objectPooler.poolDictionary)
    //        {
    //            foreach (Transform spawnPoint in pointsToSpawn)
    //            {
    //                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

    //                if (!pool.Key.Equals("Exp"))
    //                {
    //                    objectPooler.SpawnFromPool(pool.Key, new Vector3(Random.Range(transform.position.x, transform.position.x + 5),
    //                        Random.Range(transform.position.y, transform.position.y + 5), transform.position.z), spawnPoint.rotation);
    //                }
    //                //GameObject instance = (GameObject)Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    //                //instance.transform.Rotate(Vector3.up, Random.Range(0f, 360f));
    //            }
    //        }
    //    }
    //}
}
