using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>(); // Fixed method name
        rigidBody = gameObject.GetComponent<Rigidbody>(); // Use instance `gameObject`
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal);
        rigidBody.velocity = movement * speed; // Fixed `velocity` assignment

        if (xVal != 0 && yVal != 0) // Used OR (`||`) instead of AND (`&&`) to detect movement
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg,
                transform.eulerAngles.z
            );
        }
    }
}
