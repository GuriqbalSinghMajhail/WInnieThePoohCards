using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct TitleDescriptionsTiger
    {
        public string Title;
        public string Description;
    }
    [SerializeField]
    private List<TitleDescriptionsTiger> titleDescriptionsTigers;
    public struct TitleDescriptionsEeyore
    {
        public string Title;
        public string Description;
    }
    [SerializeField]
    private List<TitleDescriptionsTiger> titleDescriptionsEeeyore;
    public struct TitleDescriptionsPiglet
    {
        public string Title;
        public string Description;
    }
    [SerializeField]
    private List<TitleDescriptionsTiger> titleDescriptionsPiglet;
    private static CardGenerator instance;
    public static CardGenerator Instance
    {
        get { return instance; }
    }
    public int numberOfCards;
    [SerializeField]
    private List<CardBaseStats> cardBaseStats;
    [SerializeField]
    private GameObject[] CardPrefab;
    public List<Card> cardList;
    [SerializeField]
    private Sprite DayCardSprite;
    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0;i < numberOfCards; i++)
        {
            cardList.Add(Instantiate(CardPrefab[i % CardPrefab.Length].GetComponent<Card>()));
            int baseStatIndex = Random.Range(0, (int)(cardBaseStats.Count + 0.5f));
            cardList[i].CardBaseStats = cardBaseStats[baseStatIndex];
            cardList[i].SetStatBlock();
            cardList[i].GetComponent<SpriteRenderer>().sprite = DayCardSprite;
            cardList[i].gameObject.transform.SetParent(this.transform);
            cardBaseStats.RemoveAt(baseStatIndex);
            cardList[i].gameObject.SetActive(false);
            if (cardList[i].Character == Character.Piglet)
            {
                cardList[i].Title = titleDescriptionsPiglet[(int)Random.Range(0,titleDescriptionsPiglet.Count)].Title;
                cardList[i].Description = titleDescriptionsPiglet[(int)Random.Range(0, titleDescriptionsPiglet.Count)].Description;
            }
            else if (cardList[i].Character == Character.Eeyore)
            {
                cardList[i].Title = titleDescriptionsEeeyore[(int)Random.Range(0, titleDescriptionsEeeyore.Count)].Title;
                cardList[i].Description = titleDescriptionsEeeyore[(int)Random.Range(0, titleDescriptionsEeeyore.Count)].Description;
            }
            else if (cardList[i].Character == Character.Tiger)
            {
                cardList[i].Title = titleDescriptionsTigers[(int)Random.Range(0, titleDescriptionsTigers.Count)].Title;
                cardList[i].Description = titleDescriptionsTigers[(int)Random.Range(0, titleDescriptionsTigers.Count)].Description;
            }
        }
    }
}

