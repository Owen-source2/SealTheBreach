using UnityEngine;
using TMPro;
public class Healthbar : MonoBehaviour
{
    [SerializeField] int health = 50000;
    int baseHealth;
    public TMP_Text healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseHealth=health;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText("Gate Health: "+ health);
    }
    public void LoseHealth()
    {
        health--;
    }
    public void ResetHealth()
    {
        health=baseHealth;

    }

}
