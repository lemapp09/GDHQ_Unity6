using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    // Reference to the Minion prefab
    [SerializeField]
    private GameObject minionPrefab;

    // Spawn position for the Minion
    [SerializeField]
    private Transform spawnPosition;

    // Update is called once per frame
    void Update()
    {
        // Spawn a Minion when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnMinion();
        }
    }

    // Method to spawn the Minion
    public void SpawnMinion()
    {
        if (minionPrefab != null && spawnPosition != null)
        {
            Instantiate(minionPrefab, spawnPosition.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Minion prefab or spawn position is not assigned.");
        }
    }
}