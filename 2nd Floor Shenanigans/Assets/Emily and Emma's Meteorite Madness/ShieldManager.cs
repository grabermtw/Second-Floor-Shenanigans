using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour
{
    public Text shieldText;
    public AudioSource powerUp;

    private int shieldPoint;
    private int pointsNecessary;
    private int shieldLevel;
    private AudioSource powerDown;

    private Light shield;
    // Start is called before the first frame update
    void Start()
    {
        powerDown = GetComponent<AudioSource>();
        shield = GetComponent<Light>();
        pointsNecessary = 5;
        shieldLevel = 0;
        shieldPoint = 0;
        shieldText.text = "Needed for Shield: " + (pointsNecessary - shieldPoint).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddShieldPoint()
    {
        if (shieldLevel < 6)
        {
            shieldPoint++;
            if (shieldPoint == pointsNecessary)
            {
                powerUp.Play();
                pointsNecessary += 5;
                shieldPoint = 0;
                shieldLevel++;
                UpdateShield();
            }
            if (shieldLevel < 6)
            {
                shieldText.text = "Needed for Shield: " + (pointsNecessary - shieldPoint).ToString();
            }
            else
            {
                shieldText.text = "Shield Level Maxed!";
            }
        }
        else
        {
            shieldText.text = "Shield Level Maxed!";
        }
    }

    public void LowerLevel()
    {
        powerDown.Play();
        shieldLevel--;
        shieldText.text = "Needed for Shield: " + (pointsNecessary - shieldPoint).ToString();
        UpdateShield();
    }

    public int GetLevel()
    {
        return shieldLevel;
    }
    
    private void UpdateShield()
    {
        if(shieldLevel == 0)
        {
            shield.enabled = false;
        }
        else if(shieldLevel == 1)
        {
            shield.enabled = true;
            shield.color = Color.red;
        }
        else if (shieldLevel == 2)
        {
            shield.enabled = true;
            shield.color = Color.green;
        }
        else if (shieldLevel == 3)
        {
            shield.enabled = true;
            shield.color = Color.blue;
        }
        else if (shieldLevel == 4)
        {
            shield.enabled = true;
            shield.color = Color.magenta;
        }
        else if (shieldLevel == 5)
        {
            shield.enabled = true;
            shield.color = Color.cyan;
        }
        else if (shieldLevel == 6)
        {
            shield.enabled = true;
            shield.color = Color.yellow;
        }
    }
}
