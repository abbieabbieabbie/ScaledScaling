using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layersToCheck;
    public LayerMask winLayersToCheck;
    public Collider2D killCollider;
    public Vector3 startPos;
    public PlayerMovement player;
    public GoldenBug goldenBug;
    public GameObject winGUI;
    [HideInInspector] public bool won;

    void Update()
    {
        DetectTouch();
    }
    void DetectTouch()
    {
        if (killCollider.IsTouchingLayers(layersToCheck))
        {
           Death();
        }
        if (killCollider.IsTouchingLayers(winLayersToCheck))
        {
            if (!won)
            {
                Debug.Log("you win!");
                player.movement = Vector3.zero;
                winGUI.SetActive(true);
                won = true;
            }
        }
    }
    public void Death()
    {
        Debug.Log("game over!");
        player.movement = Vector3.zero;
        transform.position = startPos;
        StartCoroutine(ResetPos());
    }
    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(0.1f);
        winGUI.SetActive(false);
        goldenBug.Respawn();
        won = false;
    }
}
