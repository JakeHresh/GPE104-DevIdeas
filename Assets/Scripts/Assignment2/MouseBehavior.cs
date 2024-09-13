using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    public float speed;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // YOUR CODE HERE
        // Get the mouse to move forward only when you press (but do not hold) the spacebar
        // The rest of the movement logic is provided.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
        }
        if (isMoving)
        {
            Move();
        }
    }

    public void Move()
    {
        // The below instruction is something the student will need to 
        // provide on their own. e.g.
        // YOUR CODE HERE
        // Provide the instruction that will move the mouse FORWARD at a certain speed.
        transform.position += transform.forward * speed * Time.deltaTime;

        // The following Raycast code will be provided in the assignment. We might also consider having raycasts be involved
        // for an assignment 3. In this case, it is worth telling the students to specify this logic as well.
        // This is a good brain teaser.
        RaycastHit hitLeft;
        RaycastHit hitRight;
        RaycastHit hitForward;
        bool bHitLeft = false;
        bool bHitRight = false;
        bool bHitForward = false;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitForward, 0.5f))
        {
            if (hitForward.collider.gameObject.name == "Wall")
            {
                bHitForward = true;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, 0.5f))
        {
            if (hitRight.collider.gameObject.name == "Wall")
            {
                bHitRight = true;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out hitLeft, 0.5f))
        {
            if (hitLeft.collider.gameObject.name == "Wall")
            {
                bHitLeft = true;
            }
        }
        if (bHitForward && bHitLeft && bHitRight)
        {
            transform.Rotate(0f, 180f, 0f);
        }
        else if (bHitForward && bHitRight)
        {
            transform.Rotate(0f, 270f, 0f);
        }
        else if (bHitForward)
        {
            transform.Rotate(0f, 90f, 0f);
        }
    }

    // YOUR CODE HERE
    // Create the OnTriggerEnter method that will
    // force the mouse to rotate in the same direction as the arrow.

    // We can also have this work for our goal check. Obviously,
    // this breaks the single purpose principle a bit, but the code
    // itself is pretty simple. Code structure is something to really
    // emphasize in GPE205.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggerVolume")
        {
            transform.rotation = other.transform.rotation;
            transform.position = other.transform.position;
        }

        else if (other.gameObject.name == "Goal")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
