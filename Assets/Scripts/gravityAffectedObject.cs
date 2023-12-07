using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityAffectedObject : MonoBehaviour
{
    public Vector3 GravityCenter = new Vector3(0, 0, 0);
    public float GravityForce = 9.8f;

    protected Rigidbody rb;

    protected void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        Gravity();
    }

    void Gravity()
    {
        Vector3 gravity_direction = (GravityCenter - transform.position).normalized;
        Vector3 gravity = gravity_direction * GravityForce;
        rb.AddForce(gravity, ForceMode.Acceleration);

        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -gravity_direction) * transform.rotation;
        transform.rotation = targetRotation;

    }
    // Start is called before the first frame update


}
