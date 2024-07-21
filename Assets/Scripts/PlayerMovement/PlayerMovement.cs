using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4.0f;
    [SerializeField] private float _turnSpeed = 180.0f;

    private Rigidbody _playerRb;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 movementInput = InputManager.Movement;

        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y).normalized * _moveSpeed;
        _playerRb.velocity = movement;
    }

    public void RotateTowardsMouse(Vector3 mousePosition)
    {
        Vector3 direction = (mousePosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
    }



}
