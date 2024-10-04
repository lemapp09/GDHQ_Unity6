using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Reference to the Player object in the scene
    private Player player;

    // TextMeshPro fields for displaying the player's stats
    [SerializeField]
    private TMP_Text playerNameText;
    [SerializeField]
    private TMP_Text attackLevelText;
    [SerializeField]
    private TMP_Text magicLevelText;
    [SerializeField]
    private TMP_Text smithingLevelText;
    [SerializeField]
    private TMP_Text miningLevelText;

    // Color indicator Image components for the levels
    [SerializeField]
    private Image attackLevelIndicator;
    [SerializeField]
    private Image magicLevelIndicator;
    [SerializeField]
    private Image smithingLevelIndicator;
    [SerializeField]
    private Image miningLevelIndicator;

    // Start is called before the first frame update
    void Start()
    {
        // Find the Player object in the scene and get its Player script
        player = FindObjectOfType<Player>();

        if (player != null)
        {
            // Populate the UI with the player's stats
            playerNameText.text = "Player Name: " + player.playerName;
            attackLevelText.text = "Attack lvl: " + player.attackLevel.ToString();
            magicLevelText.text = "Magic lvl: " + player.magicLevel.ToString();
            smithingLevelText.text = "Smithing lvl: " + player.smithingLevel.ToString();
            miningLevelText.text = "Mining lvl: " + player.miningLevel.ToString();

            // Update the color indicators based on level values
            UpdateLevelIndicator(player.attackLevel, attackLevelIndicator);
            UpdateLevelIndicator(player.magicLevel, magicLevelIndicator);
            UpdateLevelIndicator(player.smithingLevel, smithingLevelIndicator);
            UpdateLevelIndicator(player.miningLevel, miningLevelIndicator);
        }
        else
        {
            Debug.LogWarning("Player object not found in the scene.");
        }
    }

    // Method to update the color of the level indicators based on percentage
    private void UpdateLevelIndicator(int levelValue, Image levelIndicator)
    {
        float percentage = Mathf.Clamp01(levelValue / 200f);  // Calculate percentage, clamp between 0 and 1

        // Lerp between Red (0%), Yellow (50%), and Green (100%)
        if (percentage >= 0.5f)
        {
            // Lerp between Yellow and Green
            levelIndicator.color = Color.Lerp(Color.yellow, Color.green, (percentage - 0.5f) * 2);
        }
        else
        {
            // Lerp between Red and Yellow
            levelIndicator.color = Color.Lerp(Color.red, Color.yellow, percentage * 2);
        }
    }
}
