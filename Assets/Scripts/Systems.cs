using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum DayState
{
    Day,
    Night,
}
public class Systems : MonoBehaviour
{
    private static Systems instance;
    public static Systems Instance
     
    {
        get 
        { 
            return instance; 
        }

    }
    public int SherwoodMoney;
    public int SherwoodHappiness;
    public int SherwoodDebt;
    public int DebtPercent;
    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private GameObject LoseScreen;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        SherwoodDebt = 10000;
        SherwoodHappiness = 100;
        SherwoodMoney = 100;
        DebtPercent = 5;
    }
    private void Start()
    {
        CardDeck.Instance.SpawnCards(currentDayState);
    }
    public UnityEvent<DayState> DaySwitch = new UnityEvent<DayState>();
    private DayState currentDayState;
    private int DayCounter = 0;
    public DayState SwitchDayState()
    {
        if(DayCounter >=8)
        {
            if (SherwoodMoney < SherwoodDebt)
            {
                WinScreen.SetActive(true);
            }
            if (SherwoodMoney > SherwoodDebt || SherwoodHappiness<0)
            {
                LoseScreen.SetActive(true);
            }
        }
        if(currentDayState == DayState.Day)
        {
            currentDayState = DayState.Night;
        }
        else
        {
            currentDayState = DayState.Day;
        }
        DaySwitch.Invoke(currentDayState);
        DayCounter++;
        return currentDayState;
    }
    
    void AddDebt(DayState dayState)
    {
        if (dayState == DayState.Day)
        {
            SherwoodDebt = (SherwoodDebt * DebtPercent / 100) + SherwoodDebt;
        }
    }
    
    void PrintCurrentDay(DayState dayState)
    {
        Debug.Log(currentDayState.ToString());
    }
    private void OnEnable()
    {
        DaySwitch.AddListener(PrintCurrentDay);
        DaySwitch.AddListener(AddDebt);
    }
    private void OnDisable() { 
        DaySwitch.RemoveAllListeners();
    }
}
