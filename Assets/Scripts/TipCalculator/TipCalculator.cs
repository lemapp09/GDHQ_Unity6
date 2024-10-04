using UnityEngine;
using TMPro;

public class TipCalculator : MonoBehaviour
{
    // Variables for Meal Cost and Custom Tip Percentage
    [SerializeField]
    private float _mealCost = 20.0f;
    [SerializeField]
    private float _customTipPercentage = 18.5f;

    // Meal Cost Display and Custom Tip Percentage Display
    [SerializeField]
    private TMP_Text _mealCostDisplay;
    [SerializeField]
    private TMP_Text _customTipPercentageDisplay;
    [SerializeField]
    private TMP_Text _resultsDisplay;

    // Variables for Tip and Total Cost
    private float _tip;
    private float _totalCost;

    // Start is called once before the first execution of Update
    void Start()
    {
        // Null checks for the text fields
        if (_mealCostDisplay != null)
        {
            _mealCostDisplay.text = _mealCost.ToString("C2");
        }
        else
        {
            Debug.LogWarning("Meal Cost Display text field is not assigned.");
        }

        if (_customTipPercentageDisplay != null)
        {
            _customTipPercentageDisplay.text = _customTipPercentage.ToString("F2") + "%";
        }
        else
        {
            Debug.LogWarning("Custom Tip Percentage Display text field is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Press space key to calculate tip
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Null check for results display
            if (_resultsDisplay != null)
            {
                string results = CalculateTipResults();
                _resultsDisplay.text = results;

                Debug.Log(results);  // Optional for logging
            }
            else
            {
                Debug.LogWarning("Results Display text field is not assigned.");
            }
        }
    }

    // Calculate and format the results string
    private string CalculateTipResults()
    {
        string results = "Your bill is " + _mealCost.ToString("C2") + "\n";
        results += FormatTipResult(15f);
        results += FormatTipResult(20f);
        results += FormatTipResult(25f);

        // Calculate and format the custom tip
        float customTipAmount = _mealCost * _customTipPercentage / 100f;
        float customTotalCost = _mealCost + customTipAmount;
        results += $"Your custom tip of {_customTipPercentage.ToString("F2")}% = {customTipAmount.ToString("C2")} with a total of {customTotalCost.ToString("C2")}";
        return results;
    }

    // Helper method for calculating tip based on percentage
    private string FormatTipResult(float tipPercentage)
    {
        float tipAmount = _mealCost * tipPercentage / 100f;
        float totalCost = _mealCost + tipAmount;
        return $"{tipPercentage.ToString("F2")}% tip = {tipAmount.ToString("C2")} with a final total of {totalCost.ToString("C2")}\n";
    }

    public void DisplayResults()
    {
        string results = CalculateTipResults();
        _resultsDisplay.text = results;

        Debug.Log(results);  // Optional for logging
    }
}
