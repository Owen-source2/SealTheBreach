using UnityEngine;
using TMPro;
public class TrackResources : MonoBehaviour
{
    public int gold=0;
    public TMP_Text goldText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gold=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GainGold()
    {
        gold++;
        goldText.SetText("Gold:"+gold);
    }
}
