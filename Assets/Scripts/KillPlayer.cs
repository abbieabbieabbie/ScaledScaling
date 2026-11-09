using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layersToCheck;
    public Collider2D killCollider;
    public Vector3 startPos;
    public PlayerMovement player;
    void Update()
    {
        DetectTouch();
    }
    void DetectTouch()
    {
        if (killCollider.IsTouchingLayers(layersToCheck))
        {
            Debug.Log("game over!");
            player.movement = Vector3.zero;
            transform.position = startPos;
        }
    }
}
