using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed;

    private void FixedUpdate() {
        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;
        if (keyboard.aKey.isPressed) {
            Debug.Log("A was pressed");
            this.transform.Translate(Vector3.right*speed);
        }
        if (keyboard.dKey.isPressed) {
            Debug.Log("d was pressed");
            this.transform.Translate(Vector3.left * speed);
        }

    }

}
