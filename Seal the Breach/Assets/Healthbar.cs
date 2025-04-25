using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        if(health<=0)
        {
            SceneManager.LoadScene(2);
        }
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
