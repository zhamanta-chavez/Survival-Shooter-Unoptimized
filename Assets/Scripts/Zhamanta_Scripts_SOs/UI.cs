using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField] Text text;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    [SerializeField] UI_Events visualEvents;
    [SerializeField] PlayerStats playerStats;

    private void Start()
    {
        visualEvents.AddListener(UpdateScoreVisual, UpdateHealthSlider);
    }
    void Update()
    {
        if (playerStats.damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        playerStats.damaged = false;
    }

    public void UpdateScoreVisual()
    {
        text.text = "Score: " + ScoreManager.score;
    }

    public void UpdateHealthSlider()
    {
        healthSlider.value = playerStats.currentHealth;
    }
}
