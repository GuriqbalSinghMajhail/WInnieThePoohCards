using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance {  get { return instance; } }
    [SerializeField]
    TMP_Text MoneyDisplay;
    [SerializeField]
    TMP_Text HappinessDisplay;
    [SerializeField]
    TMP_Text DebtRateDisplay;
    [SerializeField]
    TMP_Text DebtDisplay;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this);
        }

    }
    private void Start()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        ChangeDebtDisplay();
        ChangeDebtRateDisplay();
        ChangeHappinessDisplay();
        ChangeMoneyDisplay();
    }
    void ChangeMoneyDisplay()
    {
        MoneyDisplay.text = $"SherwoodMoney :- {Systems.Instance.SherwoodMoney}";
    }
    void ChangeDebtRateDisplay()
    {
        DebtRateDisplay.text = $"DebtRate :- {Systems.Instance.DebtPercent}";
    }
    void ChangeHappinessDisplay()
    {
        HappinessDisplay.text = $"Happiness :- {Systems.Instance.SherwoodHappiness}";
    }
    void ChangeDebtDisplay()
    {
        DebtDisplay.text = $"SherwoodDebt :- {Systems.Instance.SherwoodDebt}";
    }
}
