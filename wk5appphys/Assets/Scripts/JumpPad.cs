using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float bounceImpulse = 12f;

    void OnCollisionEnter(Collision c)
    {
        if (c.rigidbody == null) return;

        c.rigidbody.AddForce(Vector3.up * bounceImpulse, ForceMode.Impulse);
    }
}