using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Rigidbody mBody;

    void Awake()
    {
        mBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();

        Rotation();
    }

    private void Movement()
    {
        Vector3 direction = Vector3.zero; // Vector3 for calculating direction of the force to be applied

        if (Input.GetKey(KeyCode.A))
        {
            direction = -Vector3.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += -Vector3.forward;
        }

        mBody.AddForce(direction * movementSpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        // Create a plane that will be used to determine the position of the mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        // Create a ray that will intersect with the plane
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Distance from the intersection to the player position
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist)) // Get the distance from the intersection with the plane
        {
            // Work out the point to look at
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Change the point into rotation
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Rotate to the point of intersection
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, movementSpeed * Time.deltaTime);
        }
    }
}
