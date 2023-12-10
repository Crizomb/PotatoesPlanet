using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonMovement : MonoBehaviour
{
    public float speed;
    private float radius;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        radius = transform.position.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
        transform.LookAt(Vector3.zero);
    }
}
