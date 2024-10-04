using UnityEngine;

public class Minion : MonoBehaviour
{
    // Speed of the Minion's movement
    [SerializeField]
    private float speed = 5f;

    // The boundaries for the floor (X-axis)
    private float floorEdge = 7.5f;

    // Update is called once per frame
    void Update()
    {
        // Move the Minion to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Check if the Minion has reached the edge of the floor
        if (Mathf.Abs(transform.position.x) >= floorEdge)
        {
            Destroy(gameObject);  // Destroy the Minion when it reaches the floor edge
        }
    }
}