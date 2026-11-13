using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5f;

    Rigidbody2D rb;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public Sprite pangolinSprite;
    public Sprite newSprite;
    [HideInInspector] public Vector3 movement;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (isGrounded())
        {
            if (!gameManager.isDragging)
            {
                movement = new Vector3(x, 0, 0);
                transform.Translate(movement * speed * Time.deltaTime);
            }
            else
            {
                movement = new Vector3(0, 0, 0);
            }
        } else
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }

        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * maxDistance, boxSize);
    }
    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask))
        {
            this.GetComponent<SpriteRenderer>().sprite = pangolinSprite;
            return true;
        } else
        {
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
            return false;
        }
    }
}
