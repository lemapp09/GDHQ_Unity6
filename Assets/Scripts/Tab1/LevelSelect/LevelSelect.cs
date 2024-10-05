using UnityEngine;
using TMPro;

public class DifficultySelector : MonoBehaviour
{
    // Enum for difficulty levels
    public enum Difficulty { Easy, Medium, Hard }
    
    // SerializeField allows changing the default difficulty in the Inspector
    [SerializeField]
    private Difficulty selectedDifficulty = Difficulty.Easy;
    
    // UI elements for each difficulty level
    [SerializeField]
    private GameObject easyPanel, mediumPanel, hardPanel;
    [SerializeField]
    private TMP_Text displaySelectedLevel;

    // Update is called once per frame
    void Update()
    {
        // Display the selected difficulty when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplaySelectedDifficulty();
        }

        // Let player change the difficulty using arrow keys
        HandleDifficultySelection();
    }

    // Displays the selected difficulty in the Console and updates the UI
    public void DisplaySelectedDifficulty()
    {
        // Print the selected difficulty to the console
        Debug.Log("You selected " + selectedDifficulty.ToString() + ".");
        displaySelectedLevel.text = "You selected " + selectedDifficulty.ToString();
        
        // Update UI elements
        UpdateDifficultyUI();
    }

    // Handles input for changing difficulty at runtime
    private void HandleDifficultySelection()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Cycle difficulty left
            selectedDifficulty = (Difficulty)Mathf.Max((int)selectedDifficulty - 1, 0);
            // Update the UI to reflect the currently selected difficulty
            UpdateDifficultyUI();
            displaySelectedLevel.text = "You selected " + selectedDifficulty.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Cycle difficulty right
            selectedDifficulty = (Difficulty)Mathf.Min((int)selectedDifficulty + 1, 2);
            // Update the UI to reflect the currently selected difficulty
            UpdateDifficultyUI();
            displaySelectedLevel.text = "You selected " + selectedDifficulty.ToString();
        }
        
    }

    // Updates the visibility of the difficulty UI elements
    private void UpdateDifficultyUI()
    {
        // Make the selected difficulty visible, and hide the others
        easyPanel.gameObject.SetActive(selectedDifficulty == Difficulty.Easy);
        mediumPanel.gameObject.SetActive(selectedDifficulty == Difficulty.Medium);
        hardPanel.gameObject.SetActive(selectedDifficulty == Difficulty.Hard);
    }
}
