using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public enum Character
{
    Tiger,
    Eeyore,
    Piglet
}
public abstract class Card : MonoBehaviour
{
    
    public CardBaseStats CardBaseStats {
        set
        {
            if (value == cardBaseStats)
            {
                return;
            }
            cardBaseStats = value;
            spriteRenderer = GetComponent<SpriteRenderer>();
            
        }
        get
        {
            return cardBaseStats;
        }
    }
    private CardBaseStats cardBaseStats;
    protected Character character;
    public Character Character
    {
        get { return character; }
    }

    public string Title { get => title; set => title = value; }
    public string Description { get => description; set => description = value; }

    [SerializeField]
    protected TMP_Text TitleTMP;
    [SerializeField]
    protected TMP_Text DescriptionTMP;
    [SerializeField]
    protected TMP_Text StatTagsTMP;
    public abstract void SetStatBlock();
    

    protected string Statblock;
    private string title;
    private string description;
    private void OnEnable()
    {
        CardPlayed.AddListener(UIManager.Instance.UpdateDisplay);
        CardPlayed.AddListener(CardDeck.Instance.DestroyCards);
        SetUI();
    }
    void OnDisable()
    {
        CardPlayed.RemoveListener(UIManager.Instance.UpdateDisplay);
        CardPlayed.RemoveListener(CardDeck.Instance.DestroyCards);
    }

    SpriteRenderer spriteRenderer;
    protected UnityEvent CardPlayed = new UnityEvent();
    private void OnMouseDown()
    {
        CardPlayed.Invoke();
        Systems.Instance.SwitchDayState();   
    }

    void SetUI()
    {
        TitleTMP.text = Title;
        DescriptionTMP.text = Description;
        StatTagsTMP.text = Statblock;
    }

}
