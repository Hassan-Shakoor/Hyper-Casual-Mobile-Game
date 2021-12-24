using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePreFabs;
    public float zSpawn=0;
    public float tileLength = 30;

    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        x = -1;
        for (int i = 0; i<(tilePreFabs.Length-1); i++)
        {
            if (i == 0)
            {
                spawnTile(0);
            }
            else
            {
                spawnTile(Random.Range(0, (tilePreFabs.Length-1)));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
     if ((playerTransform.position.z-35) > zSpawn - ((tilePreFabs.Length-1) * tileLength))
        {
            x = x + 1;

            if (PlayerManager.levelNo == 1)
            {
                if (x == 6)
                {
                    spawnTile(5);
                    deleteTile();
                    return;
                }
                if (x > 6)
                {
                    return;
                }
            }

            if (PlayerManager.levelNo == 2)
            {
                if (x == 7)
                {
                    spawnTile(5);
                    deleteTile();
                    return;
                }
                if (x > 7)
                {
                    return;
                }
            }

            if (PlayerManager.levelNo == 3)
            {
                if (x == 9)
                {
                    spawnTile(5);
                    deleteTile();
                    return;
                }
                if (x > 9)
                {
                    return;
                }
            }

            spawnTile(Random.Range(0, tilePreFabs.Length - 1));
            deleteTile();

        }   
    }

    public void spawnTile(int tileIndex)
    {
        GameObject go=Instantiate(tilePreFabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    public void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
