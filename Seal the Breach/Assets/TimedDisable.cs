using UnityEngine;

public class TimedDisable : MonoBehaviour
{
    [SerializeField]float activeTime;
    float timer;
    void OnEnable()
    {
        Debug.Log("enabled");
        timer=0.0f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=activeTime)
        {
            gameObject.SetActive(false);
            Debug.Log("disabled");
        }
    }
}
