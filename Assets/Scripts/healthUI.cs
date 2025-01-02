using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    public Image heartPrefab;
    public Sprite fullHeart;
    public Sprite damagedHeart;

    private List<Image> heartList = new List<Image>();


    //tells the game that each heart in the ui is 1 HP
    public void SetMaxHearts(int maxHearts)
    { foreach (Image heart in heartList)
        {
            Destroy(heart.gameObject);
        }
        heartList.Clear();

        for (int i = 0; i < maxHearts; i++)
        {
            Image newHeart = Instantiate(heartPrefab, transform);
            newHeart.sprite = fullHeart;
            newHeart.color = Color.red;
            heartList.Add(newHeart);

        }    
    }

    //changes the status of the hearts when this funtion is called
    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            if(i < currentHealth)
            {
                heartList[i].sprite = fullHeart;
                heartList[i].color = Color.red;
            }
            else
            {
                heartList[i].sprite = damagedHeart;
                heartList[i].color = Color.gray;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
