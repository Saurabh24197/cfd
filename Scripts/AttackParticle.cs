using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AttackParticle : MonoBehaviour {

    public GameObject explosionGO;
    private Tilemap tileMap;

    public Sprite[] matchSprite;
    public GameObject[] randomLootList;
    public AudioClip explosionAudioClip;

    public float waitTime = 2f;

    private void OnEnable()
    {
        tileMap = GameObject.FindGameObjectWithTag("MasterTiles").GetComponent<Tilemap>();
        StartCoroutine(WaitTimer(waitTime));
    }

    IEnumerator WaitTimer( float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Vector3Int currentPos = new Vector3Int((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);

        foreach (Sprite spriteT in matchSprite)
        {
                DestroyTileTest(spriteT, currentPos);
                DestroyTileTest(spriteT, currentPos + new Vector3Int(0, 1, 0));
                DestroyTileTest(spriteT, currentPos + new Vector3Int(0, -1, 0));
                DestroyTileTest(spriteT, currentPos + new Vector3Int(1, 0, 0));
                DestroyTileTest(spriteT, currentPos + new Vector3Int(-1, 0, 0));
        }

        if (explosionAudioClip != null)
            AudioSource.PlayClipAtPoint(explosionAudioClip, transform.position);
        Destroy(gameObject);
    }

    void DestroyTileTest(Sprite match, Vector3Int pos)
    {
        Instantiate(explosionGO, tileMap.CellToWorld(pos), Quaternion.identity);
        Tile tile = tileMap.GetTile<Tile>(pos);
        if (tile == null) return;

        if (tile.sprite == match)
        {
            tileMap.SetTile(pos, null);
        }
    }
}
