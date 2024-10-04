using UnityEngine;
using TMPro;

public class ASL : MonoBehaviour
{
    // define age 
    [SerializeField]
    private int _age = 25;
    // define sex
    [SerializeField]
    private string _sex = "M";
    // define location  
    [SerializeField]
    private string _location = "Atlanta";
    
    // define TextMeshPro Text display
    [SerializeField]
    private TMP_Text _ageDisplay, _sexDisplay, _locationDisplay, _textDisplay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _ageDisplay.text = _age.ToString();
        _sexDisplay.text = _sex;
        _locationDisplay.text = _location;
    }

    // Update is called once per frame
    void Update()
    {
        // check for space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // print age, sex and location
            DisplayResult();
        }
    }

    public void DisplayResult()
    {
        Debug.Log(_age + " " + _sex + " " + _location);
        Debug.Log($"Age: {_age}, Sex: {_sex}, Location: {_location}");
        _textDisplay.text = $"Age: {_age}, Sex: {_sex}, Location: {_location}";
        
    }
}
