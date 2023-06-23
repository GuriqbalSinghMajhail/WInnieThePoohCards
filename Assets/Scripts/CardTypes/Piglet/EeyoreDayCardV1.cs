using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EeyoreDayCardV1 : Card
{
    private void Awake()
    {
        character = Character.Eeyore;
        this.CardPlayed.AddListener(DecreaseSherwoodRate);
        this.CardPlayed.AddListener(RemoveSherwoodMoney);
    }
    private void OnDestroy()
    {
        this.CardPlayed.RemoveAllListeners();
    }

    public override void SetStatBlock()
    {
        Statblock = $"<color=\"red\">Happiness {CardBaseStats.AddSherWoodHappiness}</color>\n<color=\"red\"> Rate {CardBaseStats.AddDebtPercent}</color>";
    }
    void DecreaseSherwoodRate()
    {
        Systems.Instance.DebtPercent -= this.CardBaseStats.AddDebtPercent;
        Debug.Log("Happened");
    }
    void RemoveSherwoodMoney()
    {
        Systems.Instance.SherwoodHappiness -= this.CardBaseStats.AddSherWoodHappiness;
        Debug.Log("No Hapennooners");
    }
    void RandomSherwoodMoney()
    {
        Systems.Instance.SherwoodMoney += this.CardBaseStats.AddSherWoodMoney;
    }

    
}
