using JetBrains.Annotations;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class drillScript : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    private SpriteRenderer spriteRenderer;
    public TMP_Text drillText;
    public TMP_Text progText;
    public TMP_Text Defend;
    public float progTime;
    public float drillSpeed = 4.2f;
    public int progress;
    public GameObject victory;
    public GameObject gameover;
    AudioSource thunkAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progress = 0;
        progTime = drillSpeed;
        thunkAudio = GetComponent<AudioSource>();
        health = maxHealth;
        textHPUpdate();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        progTime -= Time.deltaTime;
        if (progress < 100 && progTime <= 0)
        {
            progress += 2;
            progTime = drillSpeed;
            textHPUpdate();
        }
        if (progress == 100)
        {
            victory.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void craftDamage(int damage)
    {
        thunkAudio.pitch = UnityEngine.Random.Range(0.9f, 1.2f);
        thunkAudio.Play();
        health -= damage;
        textHPUpdate();
        StartCoroutine(hitFlash());
        if (health ==0)
        {
            gameover.SetActive(true );
            Defend.text = "";
            drillText.text = "Thanks for playing!";
            progText.text = "Failed!";
            Time.timeScale = 0;
        }
    }

    private IEnumerator hitFlash()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public void textHPUpdate()
    {
        drillText.text = "HP:" + health.ToString() + "/" + maxHealth.ToString();
        progText.text = "Progress: " + progress.ToString();
    }

}
