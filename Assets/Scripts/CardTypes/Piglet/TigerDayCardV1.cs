using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TigerDayCardV1 : Card
{
    
    private void Awake()
    {
        character = Character.Tiger;
        this.CardPlayed.AddListener(AddSherwoodHappiness);
        this.CardPlayed.AddListener(RemoveSherwoodMoney);
    }
    
    private void OnDestroy()
    {
        this.CardPlayed.RemoveAllListeners();
    }
    public override void SetStatBlock()
    {
        Statblock = $"<color=\"red\">Money {CardBaseStats.AddSherWoodMoney}</color>\n<color=\"green\"> Happiness {CardBaseStats.AddSherWoodHappiness}</color>";
        Debug.Log(Statblock);
    }
    void AddSherwoodHappiness()
    {
        Systems.Instance.SherwoodHappiness += this.CardBaseStats.AddSherWoodHappiness;
        Debug.Log("muney");
    }
    void RemoveSherwoodMoney()
    {
        Systems.Instance.SherwoodMoney -= this.CardBaseStats.AddSherWoodMoney;
        Debug.Log("No muney");
    }

    

}
