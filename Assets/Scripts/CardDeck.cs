using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    private static CardDeck instance;
    public static CardDeck Instance { get { return instance; } }
    [SerializeField]
    Transform position1;
    [SerializeField]
    Transform position2;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        Systems.Instance.DaySwitch.AddListener(SpawnCards);
    }
    
    public void SpawnCards(DayState dayState)
    {
        CardGenerator.Instance.cardList[0].gameObject.SetActive(true);
        CardGenerator.Instance.cardList[0].transform.position = position1.position;

        CardGenerator.Instance.cardList[1].gameObject.SetActive(true);
        CardGenerator.Instance.cardList[1].transform.position = position2.position;
    }
    public void DestroyCards()
    {
        CardGenerator.Instance.cardList[0].gameObject.SetActive(false);
        CardGenerator.Instance.cardList[1].gameObject.SetActive(false);
        CardGenerator.Instance.cardList.RemoveAt(1);
        CardGenerator.Instance.cardList.RemoveAt(0);
    }

}
