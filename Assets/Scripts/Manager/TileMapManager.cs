using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    private List<TileMap> tileMaps;

    public GameObject tileMapPrefab;

    [SerializeField]
    public int m_TileMapBlockWidth = 100;

    public GameObject playerReferencer;

    private int m_PlayerTileMapPosition;

    [SerializeField]
    private float TimeBetweenRecalculations;

    private float m_TimeBetweenRecalculations;

    public int PlayerTileMapPostion
    {
        get { return m_PlayerTileMapPosition; }
        set
        {
            if(m_PlayerTileMapPosition != value)
            {
                m_PlayerTileMapPosition = value;
                UpdateTileMap();
            }               
        }
    }

    private void UpdateTileMap()
    {
        switch (PlayerTileMapPostion)
        {
            case 0:
                PlaceTileMapBlock(tileMaps[2], 0, 1);
                PlaceTileMapBlock(tileMaps[6], 0, 1);
                PlaceTileMapBlock(tileMaps[5], 0, 2);
                PlaceTileMapBlock(tileMaps[7], 0, 2);
                PlaceTileMapBlock(tileMaps[8], 0, 3);

                //Update tilemap block position
                tileMaps[8].Position = 0;
                tileMaps[5].Position = 1;
                //tileMaps[2].Position = 2;
                tileMaps[7].Position = 3;
                tileMaps[0].Position = 4;
                tileMaps[1].Position = 5;
                //tileMaps[6].Position = 6;
                tileMaps[3].Position = 7;
                tileMaps[4].Position = 8;
                break;

            case 1:
                PlaceTileMapBlock(tileMaps[6], 1, 3);
                PlaceTileMapBlock(tileMaps[7], 1, 3);
                PlaceTileMapBlock(tileMaps[8], 1, 3);

                //Update tilemap block position
                tileMaps[6].Position = 0;
                tileMaps[7].Position = 1;
                tileMaps[8].Position = 2;
                tileMaps[0].Position = 3;
                tileMaps[1].Position = 4;
                tileMaps[2].Position = 5;
                tileMaps[3].Position = 6;
                tileMaps[4].Position = 7;
                tileMaps[5].Position = 8;
                break;

            case 2:
                PlaceTileMapBlock(tileMaps[0], 2, 1);
                PlaceTileMapBlock(tileMaps[8], 2, 1);
                PlaceTileMapBlock(tileMaps[3], 2, 2);
                PlaceTileMapBlock(tileMaps[7], 2, 2);
                PlaceTileMapBlock(tileMaps[6], 2, 3);

                //Update tilemap block position
                //tileMaps[0].Position = 0;
                tileMaps[3].Position = 1;
                tileMaps[6].Position = 2;
                tileMaps[1].Position = 3;
                tileMaps[2].Position = 4;
                tileMaps[7].Position = 5;
                tileMaps[4].Position = 6;
                tileMaps[5].Position = 7;
                //tileMaps[8].Position = 8;
                break;
            case 3:
                PlaceTileMapBlock(tileMaps[2], 3, 3);
                PlaceTileMapBlock(tileMaps[5], 3, 3);
                PlaceTileMapBlock(tileMaps[8], 3, 3);

                //Update tilemap block position
                tileMaps[2].Position = 0;
                tileMaps[0].Position = 1;
                tileMaps[1].Position = 2;
                tileMaps[5].Position = 3;
                tileMaps[3].Position = 4;
                tileMaps[4].Position = 5;
                tileMaps[8].Position = 6;
                tileMaps[6].Position = 7;
                tileMaps[7].Position = 8;
                break;
            case 4:
                break;
            case 5:
                PlaceTileMapBlock(tileMaps[0], 5, 3);
                PlaceTileMapBlock(tileMaps[3], 5, 3);
                PlaceTileMapBlock(tileMaps[6], 5, 3);

                //Update tilemap block position
                tileMaps[1].Position = 0;
                tileMaps[2].Position = 1;
                tileMaps[0].Position = 2;
                tileMaps[4].Position = 3;
                tileMaps[5].Position = 4;
                tileMaps[3].Position = 5;
                tileMaps[7].Position = 6;
                tileMaps[8].Position = 7;
                tileMaps[6].Position = 8;
                break;
            case 6:
                PlaceTileMapBlock(tileMaps[0], 6, 1);
                PlaceTileMapBlock(tileMaps[8], 6, 1);
                PlaceTileMapBlock(tileMaps[1], 6, 2);
                PlaceTileMapBlock(tileMaps[5], 6, 2);
                PlaceTileMapBlock(tileMaps[2], 6, 3);

                //Update tilemap block position
                //tileMaps[0].Position = 0;
                tileMaps[3].Position = 1;
                tileMaps[4].Position = 2;
                tileMaps[1].Position = 3;
                tileMaps[6].Position = 4;
                tileMaps[7].Position = 5;
                tileMaps[2].Position = 6;
                tileMaps[5].Position = 7;
                //tileMaps[8].Position = 8;
                break;
            case 7:
                PlaceTileMapBlock(tileMaps[0], 7, 3);
                PlaceTileMapBlock(tileMaps[1], 7, 3);
                PlaceTileMapBlock(tileMaps[2], 7, 3);

                //Update tilemap block position
                tileMaps[3].Position = 0;
                tileMaps[4].Position = 1;
                tileMaps[5].Position = 2;
                tileMaps[6].Position = 3;
                tileMaps[7].Position = 4;
                tileMaps[8].Position = 5;
                tileMaps[0].Position = 6;
                tileMaps[1].Position = 7;
                tileMaps[2].Position = 8;
                break;
            case 8:
                PlaceTileMapBlock(tileMaps[2], 8, 1);
                PlaceTileMapBlock(tileMaps[6], 8, 1);
                PlaceTileMapBlock(tileMaps[1], 8, 2);
                PlaceTileMapBlock(tileMaps[3], 8, 2);
                PlaceTileMapBlock(tileMaps[0], 8, 3);

                //Update tilemap block position
                tileMaps[4].Position = 0;
                tileMaps[5].Position = 1;
                //tileMaps[2].Position = 2;
                tileMaps[7].Position = 3;
                tileMaps[8].Position = 4;
                tileMaps[1].Position = 5;
                //tileMaps[6].Position = 6;
                tileMaps[3].Position = 7;
                tileMaps[0].Position = 8;
                break;
            default:
                break;
        }
        //Sort
        tileMaps.Sort((x, y) => x.Position.CompareTo(y.Position));
    }

    private void Awake()
    {
        m_TimeBetweenRecalculations = TimeBetweenRecalculations;
        tileMaps = new List<TileMap>(new TileMap[9]);
        InitTileMap();
        playerReferencer = GameObject.FindGameObjectWithTag("Player");
        PlayerTileMapPostion = tileMaps[4].Position;
    }

    // Update is called once per frame
    void Update()
    {
        m_TimeBetweenRecalculations -= Time.deltaTime;
        if(m_TimeBetweenRecalculations > 0)
        {
            return;
        }
        m_TimeBetweenRecalculations = TimeBetweenRecalculations;
        if (playerReferencer  == null)
        {
            playerReferencer = GameObject.FindGameObjectWithTag("Player");
        }
        PlayerTileMapPostion = GetTileMapPositionClosetToPlayer();
        Debug.Log(PlayerTileMapPostion);
    }

    private void InitTileMap()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject gameObject = Instantiate(tileMapPrefab);
            TileMap tileMap = new TileMap {
                Position = i,
                TheObject = gameObject,
            };
            tileMaps[i] = tileMap;
            PlaceTileMapBlock(tileMap, i);
        }
    }

    private void PlaceTileMapBlock(TileMap tileMap, int pos, int steps = 1)
    {
        Vector2 dir = GetDirectionFromPos(pos) * steps;
        Vector2 currentPos = tileMap.TheObject.transform.position;
        Vector2 newPos = currentPos + new Vector2(
            (m_TileMapBlockWidth) * dir.x,
            (m_TileMapBlockWidth) * dir.y
        );
        tileMap.TheObject.transform.position = newPos;
    }

    private int GetTileMapPositionClosetToPlayer()
    {
        float dist = Mathf.Infinity;
        int champ = -1;
        for (int i = 0; i < 9; i++)
        {
            TileMap tileMap = tileMaps[i];
            float tmpDist = Vector2.Distance(tileMap.TheObject.transform.position
                , playerReferencer.transform.position);
            if(tmpDist < dist)
            {
                dist = tmpDist;
                champ = tileMap.Position;
            }
        }

        return champ;
    }

    private Vector2 GetDirectionFromPos(int pos)
    {
        switch (pos)
        {
            case 0:
                return new Vector2(-1, 1);
            case 1:
                return new Vector2(0, 1);
            case 2:
                return new Vector2(1, 1);
            case 3:
                return new Vector2(-1, 0);
            case 4:
                return new Vector2(0, 0);
            case 5:
                return new Vector2(1, 0);
            case 6:
                return new Vector2(-1, -1);
            case 7:
                return new Vector2(0, -1);
            case 8:
                return new Vector2(1, -1);
            default:
                return new Vector2(0, 0);

        }
    }

    public class TileMap 
    {
        public int Position;
        public GameObject TheObject;
    }
}
