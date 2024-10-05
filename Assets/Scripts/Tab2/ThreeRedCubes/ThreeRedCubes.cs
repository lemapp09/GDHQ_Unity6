using UnityEngine;
using UnityEngine.Serialization;

public class ThreeRedCubes : MonoBehaviour
{
    // Array to hold the cubes, private but exposed in the Inspector
    [FormerlySerializedAs("cubes")] [SerializeField]
    private GameObject[] _cubeArray;
    
    [SerializeField]
    private float _colorChangeDelay = 5f;

    // Array to store the original colors of the _cubeArray
    private Color[] originalColors;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the originalColors array
        originalColors = new Color[_cubeArray.Length];

        // Capture the initial color of each cube at the start
        for (int i = 0; i < _cubeArray.Length; i++)
        {
            if (_cubeArray[i] != null)
            {
                originalColors[i] = _cubeArray[i].GetComponent<MeshRenderer>().material.color;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Change the color of all cubes to red when the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCubesColor();
        }
    }

    // Public method to change the cubes' color to red, also accessible from an on-screen button
    public void ChangeCubesColor()
    {
        foreach (GameObject cube in _cubeArray)
        {
            if (cube != null)
            {
                // add null check on GetComponent here
                if (cube.GetComponent<MeshRenderer>() != null)
                {
                    cube.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }

        // Invoke the method to restore the original colors after 5 seconds
        Invoke("RestoreOriginalColors", _colorChangeDelay);
    }

    // Method to restore the original colors of the cubes
    private void RestoreOriginalColors()
    {
        for (int i = 0; i < _cubeArray.Length; i++)
        {
            if (_cubeArray[i] != null)
            {
                _cubeArray[i].GetComponent<MeshRenderer>().material.color = originalColors[i];
            }
        }
    }
}