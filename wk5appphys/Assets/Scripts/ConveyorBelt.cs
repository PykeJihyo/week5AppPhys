using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] float beltSpeed = 3f;

    void OnCollisionStay(Collision c)
    {
        Rigidbody rb = c.rigidbody;
        if (rb == null) return;

        // transform.forward represents the direction the belt is facing.
        Vector3 pushDirection = transform.forward;

        // Detect if the belt is flat or diagonal by checking the vertical tilt
        if (Mathf.Abs(pushDirection.y) < 0.01f)
        {
            Debug.Log("Conveyor is flat.");
        }
        else
        {
            Debug.Log("Conveyor is diagonal.");
        }

        // Project the cube's velocity along the belt's direction
        float currentSpeedAlongBelt = Vector3.Dot(rb.linearVelocity, pushDirection);
        float missing = beltSpeed - currentSpeedAlongBelt;

        // Apply force using VelocityChange to carry any mass to the same belt speed
        rb.AddForce(pushDirection * missing, ForceMode.VelocityChange);
    }
}
