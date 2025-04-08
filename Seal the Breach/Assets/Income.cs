using UnityEngine;

public class Income : MonoBehaviour
{
    [SerializeField]enum buildingType
    {
        House
    }
    float timer=0.0f;
    [SerializeField]float waitTime=15.0f;
    [SerializeField]GameObject scoreboard;
    buildingType building=buildingType.House;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(scoreboard==null)
        {
            scoreboard=GameObject.Find("Canvas/Gold");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=waitTime)
        {
            Debug.Log("Time up");
            switch(building)
            {
                case buildingType.House:
                    scoreboard.GetComponent<TrackResources>().GainGold();
                    Debug.Log("Gold Up");
                    break;
            }
            timer=0.0f;
        }
        
    }
}
