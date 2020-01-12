using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class RandomBlock : MonoBehaviour {

    public Tilemap tilemap;
    public Tilemap collidableTilemap;
    public Tilemap animationTilemap;

    public Tile default_tile;
    public Tile block;

    public AnimatedTile block_tilePrefabAnimated;
    private float block_animation_time;



    public int width, height;
    public int x, y;
    float nextTime = 0;
    List<Vector3Int> blockList = new List<Vector3Int>();
    int numBlocks = 10;

    void Start() {
        block_animation_time =
            block_tilePrefabAnimated.m_AnimatedSprites.Length / block_tilePrefabAnimated.m_MinSpeed;
        Debug.Log(block_tilePrefabAnimated.m_AnimatedSprites.Length);
        Debug.Log(block_tilePrefabAnimated.m_MinSpeed);
    }

    void Update() {
        if (Time.time >= nextTime) {
            if (blockList.Count != 0) {
                for (int i = 0; i < blockList.Count; i++) {
                    Vector3Int element = blockList[i];
                    collidableTilemap.SetTile(element, null);
                    blockList.Remove(element);
                }
            }

            for (int i = 0; i < numBlocks; i++) {
                x = Random.Range(0, width);
                y = Random.Range(0, height);
                Vector3Int pos = new Vector3Int(x, y, 0);
                StartCoroutine(AddObstacle(pos));

                blockList.Add(pos);
            }
            nextTime += 6;
            numBlocks = numBlocks +5;
        }
    }

    public IEnumerator AddObstacle(Vector3Int pos) {

        animationTilemap.SetTile(pos, block_tilePrefabAnimated); // animation

        yield return new WaitForSeconds(block_animation_time);
        animationTilemap.SetTile(pos, null);
        collidableTilemap.SetTile(pos, block);
    }
}


