using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Card", menuName = "Create Card")]
public class CardBaseStats : ScriptableObject
{
    
    //public Sprite Sprite;
    public DayState DayState;
    public int AddSherWoodMoney;
    public int AddSherWoodDebt;
    public int AddSherWoodHappiness;
    public int AddDebtPercent;
}
