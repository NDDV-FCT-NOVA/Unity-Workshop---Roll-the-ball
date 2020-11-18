using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public UnityEvent gameWon = new UnityEvent();

    [SerializeField] float moveForce = 300f;
    [SerializeField] float groundcheckRange = 3f;
    [SerializeField] LayerMask groundLayer; // How far the ray should be cast to look for ground

    bool isGrounded;

    #region Input
        Vector2 movInput;
    #endregion


    #region References
        Rigidbody rb;
        Camera cam;
    #endregion

    private void Start() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main; // Doing this sucks, avoid doing this as much as you can
    }

    private void FixedUpdate() {
        
        isGrounded = Physics.Raycast(transform.position, -transform.up, groundcheckRange, groundLayer); // Shoot ray down and check if hit ground

        if(isGrounded)
            HandleMovement();
    }

    internal void ReceiveMovementInput(Vector2 input)
    {
        movInput = input;
    }

    public void HandleMovement()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 mov = movInput.y*forward + movInput.x*right;

        rb.AddForce(mov * moveForce);
    }

   private void OnTriggerEnter(Collider other) {
       Debug.Log("GG");
       gameWon.Invoke();
   }
}