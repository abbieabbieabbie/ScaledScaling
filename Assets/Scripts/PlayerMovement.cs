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
            if (!Input.GetMouseButtonDown(0))
            {
                Vector3 movement = new Vector3(x, 0, 0);
                transform.Translate(movement * speed * Time.deltaTime);
            }
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
            return true;
        } else
        {
            return false;
        }
    }
}
