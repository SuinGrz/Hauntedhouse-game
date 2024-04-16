// Update is called once per frame
using UnityEngine;

void Update()
{
    // Find a pineapple if one does not exist.
    if (closest == null)
    {
        closest = FindClosest();
        slowedDown = false;
        currentSpeed = MAX_SPEED;
        if (closest == null)
        {
            return;
        }
    }
    // Determine the direction to the closest pineapple.
    Vector3 direction = closest.transform.position - transform.position;
    // Calculates the length of the relative position vector
    float distance = direction.magnitude;
    // Face in the right direction.
    direction.y = 0;
    if (direction.magnitude > 0)
    {
        Quaternion rotation = Quaternion.LookRotation(-direction, Vector3.up);
        transform.rotation = rotation;
    }
    // Calculate the normalised direction to the target from a game object.
    Vector3 normDirection = direction / distance;
    // Adjust speed based on distance.
    if (distance < CLOSE_DISTANCE && slowedDown == false)
    {
        currentSpeed *= 0.5f;
        slowedDown = true;
    }
    // Move the game object.
    transform.position = transform.position + normDirection * currentSpeed * Time.deltaTime;
}