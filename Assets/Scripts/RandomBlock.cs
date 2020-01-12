using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class RandomBlock : MonoBehaviour
{

    public Tilemap tilemap;
    public Tile default_tile;
    public Tile obstacle;
    public Tile red_tile;
    public Tile orange_tile;
    public GameObject character;


    public int width, height;
    public int x, y;
    float nextTime =3;
    float flickerTime = 3;
    bool flicker = true;
    List<Vector3Int> blockList = new List<Vector3Int>();

    void Update()
    {
        if (Time.time >= nextTime)
        {
            foreach (Vector3Int element in blockList)
            {
                tilemap.SetTile(element, default_tile);
                blockList.Remove(element);
            }
            for (int i = 0; i < 50; i++)
            {
                x = Random.Range(0, width);
                y = Random.Range(0, height);
                Vector3Int vector = new Vector3Int(x, y, 0);

                float charPosX = character.transform.position.x;
                float charPosY = character.transform.position.y;
                //if (System.Math.Abs(charPosX - vector.x ) > 2
                        //&& System.Math.Abs(charPosY - vector.transform.position.y) > 2 ){
                    tilemap.SetTile(vector, red_tile);
                    blockList.Add(vector);
                //}
            }
            nextTime += 5;
        }

        //else
        //{
        //    if (flicker) {
        //        foreach (Vector3Int element in blockList)
        //        {
        //            tilemap.SetTile(element, orange_tile);
        //        }
        //    }
        //    else
        //    {
        //        foreach (Vector3Int element in blockList)
        //        {
        //            tilemap.SetTile(element, null);
        //        }
        //    }
        }
        




    }


    //public IEnumerator waitFunction(int x)
    //{
    //    yield return new WaitForSeconds(x);

    //}


