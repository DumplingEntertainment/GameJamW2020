using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {

    public Tilemap map;
    public Tile default_tile;
    public Tile red_tile;

    public int width, height;

    private int x, y;


    void Update() {
        if (Time.time > 5) {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
            map.SetTile(new Vector3Int(x, y, 0), red_tile);
        }

        if (Time.time < 10) {
            
        }
    }

}
