using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yval = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yval);
        rigidBody.velocity = movement * speed;

        if (xVal != 0 && yval != 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yval) * Mathf.Rad2Deg, transform.eulerAngles.z);
    }
}
