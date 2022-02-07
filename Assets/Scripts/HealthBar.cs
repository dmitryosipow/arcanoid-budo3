using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //private const int BASIC_HEALTH = 3;
    
    public Image[] hearts;
    public Sprite full;
    public Sprite empty;

    public int totalHealth;
    public int currentHealth;

    // Update is called once per frame
    private void UpdateBar()
    {
        //print("currentHealth " + currentHealth);
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = full;
            }
            else
            {
                hearts[i].sprite = empty;
            }

            if (i < totalHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        // If incoming health is more than total health, but it should be no less than basic
        totalHealth = Mathf.Max(currentHealth, totalHealth);
        totalHealth = Mathf.Min(totalHealth, hearts.Length);
        Debug.Log("yo");
        Debug.Log(currentHealth);
        UpdateBar();
    }

    public void Reset()
    {
        SetHealth(totalHealth);
    }
}
