using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    float timer=0.0f;
    [SerializeField]float waitTime=15.0f;
    [SerializeField]GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=waitTime)
        {
            Instantiate(enemy,transform.position,transform.rotation);
            
            //Debug.Log(transform.position);
            timer=0.0f;
        }
    }
}
