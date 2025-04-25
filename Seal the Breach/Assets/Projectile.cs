using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]float missileSpeed=100.0f;
    public GameObject target;
    Rigidbody rb;
    Vector3 trajectory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(target.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            transform.position=Vector3.Lerp(transform.position,Vector3.MoveTowards(transform.position,target.transform.position,99999),0.2f);
        }
        else
        {
            Destroy(gameObject,1.0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
