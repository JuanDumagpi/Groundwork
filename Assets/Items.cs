
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Items : MonoBehaviour
{
    public int copperCount;
    public int silverCount;
    public TMP_Text copper;
    public TMP_Text silver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateCopperAmt()
    {
        copper.text = ": " +copperCount.ToString();

    }
    public void updateSilverAmt()
    {
        silver.text = ": " + silverCount.ToString();

    }

}
