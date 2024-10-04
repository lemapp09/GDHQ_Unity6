using UnityEngine;

public class QuickChangeAct : MonoBehaviour
{
    // Speed of the player movement
    [SerializeField]
    private float moveSpeed = 5f;

    // Movement boundaries for clamping the Player's X position
    private float minX = -2.43f;
    private float maxX = 2.43f;

    // Array of predefined pastel colors in Color format
    private readonly Color[] pastelColors = {
        new Color(0xF9 / 255f, 0xC6 / 255f, 0xD3 / 255f),  // Pastel Pink
        new Color(0xAE / 255f, 0xC6 / 255f, 0xCF / 255f),  // Pastel Blue
        new Color(0xC1 / 255f, 0xE1 / 255f, 0xC1 / 255f),  // Pastel Green
        new Color(0xFD / 255f, 0xFD / 255f, 0x96 / 255f),  // Pastel Yellow
        new Color(0xCD / 255f, 0xB4 / 255f, 0xDB / 255f),  // Pastel Purple
        new Color(0xFF / 255f, 0xDA / 255f, 0xB9 / 255f)   // Pastel Peach
    };

    void Update()
    {
        // Handle player movement left and right
        MovePlayer();
    }

    // Method to move the player
    private void MovePlayer()
    {
        // Get input from arrow keys
        float moveInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(moveInput, 0, 0);

        // Clamp the X position within the bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Apply the new position to the player
        transform.position = newPosition;
    }

    // Method to change the player's color to a random pastel color
    public void ChangePlayerColor()
    {
        Renderer playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            // Select a random pastel color from the array
            Color randomColor = pastelColors[Random.Range(0, pastelColors.Length)];
            playerRenderer.material.color = randomColor;
        }
        else
        {
            Debug.LogWarning("Player does not have a Renderer component.");
        }
    }
}
