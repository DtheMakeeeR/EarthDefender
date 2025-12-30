using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private InputActionAsset InputActions;
    private InputAction m_moveAction;
    private InputAction m_jumpAction;
    private InputAction m_shootAction;

    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private float speed = 5;
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        m_moveAction = InputActions.FindAction("Move");
        m_jumpAction = InputActions.FindAction("Jump");
        m_shootAction = InputActions.FindAction("Shoot");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector2 moveDirection;
        moveDirection = m_moveAction.ReadValue<Vector2>().normalized;
        body.linearVelocityX = moveDirection.x * speed;
    }
}
