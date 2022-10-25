using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnManager : MonoBehaviour
{
    ObjectPooler objectPooler;

    private float spawnTimer;

    [SerializeField]
    private Tilemap tileMap;

    [SerializeField]
    private List<Vector3> availablePlaces;

    void Start()
    {
        spawnTimer = 0;
        objectPooler = ObjectPooler.Instance;
        FindLocationsOfTiles();
    }

    private void FindLocationsOfTiles()
    {
        availablePlaces = new List<Vector3>(); // create a new list of vectors by doing...

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax + 39; n++) // scan from left to right for tiles
        {
            for (int p = tileMap.cellBounds.yMax + 39; p >= tileMap.cellBounds.yMin; p--) // scan from bottom to top for tiles
            {
                Vector3Int localPlace = new Vector3Int(Random.Range(n,p), Random.Range(n,p), (int)tileMap.transform.position.y); // if you find a tile, record its position on the tile map grid
                Vector3 place = tileMap.CellToWorld(localPlace); // convert this tile map grid coords to local space coords
                if (tileMap.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlaces.Add(place);
                }
            }
        }
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        InvokeRepeating("SpawnBoulder", spawnTimer, 0.5f);


    }

    private void SpawnBoulder()
    {
        if (spawnTimer <= 0)
        {
            for (int i = 0; i < availablePlaces.Count; i++)
            {
                foreach(var pool in objectPooler.poolDictionary)
                {
                    objectPooler.SpawnFromPool(pool.Key,new Vector3(Random.Range(availablePlaces[i].x, availablePlaces[i].x + 0.5f), Random.Range(availablePlaces[i].y, availablePlaces[i].y + 0.5f), availablePlaces[i].z), Quaternion.identity);

                }
            }
            spawnTimer = 2f;
        }
    
    }
  
}
