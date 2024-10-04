using UnityEngine;

public class ColorChangeTrigger : MonoBehaviour
{
    // Trigger method when the player enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the Player (tagged as "Player")
        if (other.gameObject.CompareTag("Player"))
        {
            // Try to get the QuickChangeAct component from the Player
            QuickChangeAct quickChange = other.gameObject.GetComponent<QuickChangeAct>();

            // Perform a null check to ensure the component exists
            if (quickChange != null)
            {
                // Call the method to change the Player's color
                quickChange.ChangePlayerColor();
            }
            else
            {
                Debug.LogWarning("QuickChangeAct component not found on the Player.");
            }
        }
    }
}