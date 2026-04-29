using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shot;
    [SerializeField] InputActionReference Special;
    [SerializeField] GameObject ShotPrefab;
    [SerializeField] GameObject SpecialPrefab;
    [SerializeField] Transform ShootingPoint;
    [SerializeField] Animator animator;
    Rigidbody2D rb2d;
    [SerializeField] float linearVelocity = 3f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        move.action.started += OnMove;
        move.action.canceled += OnMove;
        move.action.performed += OnMove;
        shot.action.started += OnShot;
        Special.action.started += OnSpecial;
    }

    private void Update()
    {
        rb2d.linearVelocity = rawmove * linearVelocity;
        if (rawmove != Vector2.zero)
        {
            animator.SetBool("IsMoving",true);
        }
        else
        {
            animator.SetBool("IsMoving",false);
        }
    }

    Vector2 rawmove = Vector2.zero;
    void OnMove(InputAction.CallbackContext context)
    {
        rawmove = context.action.ReadValue<Vector2>();
    }

    void OnShot(InputAction.CallbackContext context)
    {
        Instantiate(ShotPrefab, ShootingPoint.position, quaternion.identity);
    }

    void OnSpecial(InputAction.CallbackContext context)
    {
        if(ShootingPoint == null) return;
        if (Global.instance.specialBar >=1)
        {
            print(Global.instance.specialBar);
            Global.instance.ResetSpecial();
            Instantiate(SpecialPrefab, ShootingPoint.position, quaternion.identity);
            
        }
    }

    void OnEnable()
    {
        move.action.Enable();
        shot.action.Enable();
        Special.action.Enable();
    }

    void OnDisable()
    {
        move.action.Disable();
        shot.action.Disable();
        Special.action.Disable();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Global.instance.LoseLive(1);
        }
        else if (collision.collider.CompareTag("EliteEnemy"))
        {
            Global.instance.LoseLive(2);
        }
    }


}
