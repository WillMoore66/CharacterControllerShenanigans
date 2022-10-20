using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] float sprintSpeed;
    [SerializeField] float walkSpeed;
    private float speed;
    private bool isSprinting;
    private bool isGrounded;

    private void FixedUpdate() {
        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        speed = keyboard.eKey.isPressed ? sprintSpeed : walkSpeed;

        if (keyboard.aKey.isPressed) {
            Debug.Log("A was pressed");
            this.transform.Translate(Vector3.right * speed);
        }
        if (keyboard.dKey.isPressed) {
            Debug.Log("d was pressed");
            this.transform.Translate(Vector3.left * speed);
        }
       
    }

    private void GroundCheck() {
       
    }

}
