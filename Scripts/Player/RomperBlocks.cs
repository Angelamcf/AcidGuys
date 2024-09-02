using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RomperBlocks : MonoBehaviour
{
     public RuleTile grasstile;
    public Tilemap groundTileMap;

    public float castDistance = 1.0f;
    public Transform raycastPoint;
    public LayerMask layer;

    float blockDestroyTime = 0.2f;
    Vector3 direction;
    RaycastHit2D hit;

    bool destroyingBlock = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RaycastDirection();
            //Debug.Log("Raycast");
        }
    }

    void RaycastDirection()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (direction.magnitude > 0)
        {
            hit = Physics2D.Raycast(raycastPoint.position, direction, castDistance, layer);

            Vector2 endpos = raycastPoint.position + direction;

            Debug.DrawLine(raycastPoint.position, endpos, Color.red);

            Debug.Log("Hit collider: " + hit.collider);

            if (Input.GetKey(KeyCode.E))
            {
                if (hit.collider && !destroyingBlock)
                {
                    Tilemap map = hit.collider.gameObject.GetComponent<Tilemap>();
                    Debug.Log("Map: " + map);

                    if (map != null)
                    {
                        destroyingBlock = true;
                        StartCoroutine(DestroyBlock(map, endpos));
                        Debug.Log("Destroy");
                    }
                    else
                    {
                        Debug.Log("No Tilemap component found");
                    }
                }
                else
                {
                    Debug.Log("No collider hit or already destroying block");
                }
            }
        }
    }

    IEnumerator DestroyBlock(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(blockDestroyTime);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);

        destroyingBlock = false;
    }
}