using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    Camera cam;
    public PlayerTraj ball;
    public Trajectory trajectory;

    public PlayerMovement grounded;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && (grounded.isGrounded()))
        {
            isDragging = true;
            OnDragStart();
        } else if(Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.Space)))
        {
            ball.Cancel();
        }
        if (Input.GetMouseButtonUp(0) && (grounded.isGrounded()))
        {
            isDragging = false;
            OnDragEnd();
        }
        if (isDragging && (grounded.isGrounded()))
        {
            OnDrag();
        }
    }

    void OnDragStart()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint,endPoint);
        Debug.Log(distance);
        if (distance > 2.4)
        {
            distance = 2.4f;
        }
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        Debug.DrawLine(startPoint,endPoint);
        trajectory.UpdateDots(ball.pos, force);
    }
    void OnDragEnd()
    {
        
        if (grounded.isGrounded())
        {
            ball.ActiveRigidbody();
            ball.Sling(force);

            trajectory.Hide();
        }
    }
}
