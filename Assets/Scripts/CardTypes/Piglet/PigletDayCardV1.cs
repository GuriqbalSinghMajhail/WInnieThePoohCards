using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigletDayCardV1 : Card
{
    private void Awake()
    {
        character = Character.Piglet;
        this.CardPlayed.AddListener(AddSherwoodMoney);
        this.CardPlayed.AddListener(RemoveSherwoodHappiness);
    }

    public override void SetStatBlock()
    {
        Statblock = $"<color=\"green\">Money {CardBaseStats.AddSherWoodMoney}</color>\n<color=\"red\"> Happiness {CardBaseStats.AddSherWoodHappiness}</color>";
    } 
    void AddSherwoodMoney()
    {
        Systems.Instance.SherwoodMoney += this.CardBaseStats.AddSherWoodMoney;
        Debug.Log("muney");
    }
    void RemoveSherwoodHappiness()
    {
        Systems.Instance.SherwoodHappiness -= this.CardBaseStats.AddSherWoodHappiness;
        Debug.Log("No muney");
    }

}
