    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] float speed;
    Vector2 move;
    [SerializeField] float RotationSmoothness;
    PlayerInput playerInput;
    bool hold = false;
    

    float angle;
    int hp;


    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerManager.addPlayer(this.gameObject);
        playerInput = GetComponent<PlayerInput>();
    }

    private void Move()
    {
        if (!hold)
        {
            Vector3 movement = new Vector3(move.x, 0, move.y);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
            LerpRotation();
    }

    void LerpRotation()
    {
        Quaternion curRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
        Quaternion lerpedRotation = Quaternion.Lerp(curRotation, targetRotation, RotationSmoothness);
        transform.rotation = lerpedRotation;
    }

    

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        if (move.sqrMagnitude > 0.1f) {
            angle = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;
        }
    }

    void OnHold(InputValue value)
    {
     
        hold = value.isPressed;
    }

    

    public bool isOwner(int id)
    {
        return id == playerInput.playerIndex;
    }

    public int Index => playerInput.playerIndex;





}
