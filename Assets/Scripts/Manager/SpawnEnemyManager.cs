using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemyManager : MonoBehaviour
{
    ObjectPooler objectPooler;

    [Header("Spawn System")]
    [SerializeField]
    private float spawnTimer = 0f;

    [SerializeField]
    private Tilemap tileMap;

    [SerializeField]
    private List<Vector3> availablePlaces;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        FindLocationsOfTiles();
    }

    private void FindLocationsOfTiles()
    {
        availablePlaces = new List<Vector3>(); // create a new list of vectors by doing...

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++) // scan from left to right for tiles
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++) // scan from bottom to top for tiles
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)tileMap.transform.position.y); // if you find a tile, record its position on the tile map grid
                Vector3 place = tileMap.CellToWorld(localPlace); // convert this tile map grid coords to local space coords
                if (tileMap.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlaces.Add(place);
                }
                else
                {
                    //No tile at "place"
                }
            }
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        InvokeRepeating("SpawnBoulder", spawnTimer, 0.05f);


    }

    private void SpawnBoulder()
    {
        if (spawnTimer > 2)
        {
            for (int i = 0; i < availablePlaces.Count; i++)
            {
                objectPooler.SpawnFromPool("Enemy", new Vector3(Random.Range(availablePlaces[i].x, availablePlaces[i].x + 0.5f), Random.Range(availablePlaces[i].y, availablePlaces[i].y + 0.5f), availablePlaces[i].z) ,Quaternion.identity);
            }
            spawnTimer = 0f;
        }
    
    }
  
}
