using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Archer : MonoBehaviour
{
    [SerializeField]float range = 200.0f;
    [SerializeField]GameObject arrow;
    [SerializeField]GameObject scoreboard;
    public GameObject nearestEnemy;
    float timer=0.0f;
    [SerializeField]float waitTimeInit=15.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        nearestEnemy=gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        float waitTime=waitTimeInit*10/(scoreboard.GetComponent<TrackResources>().gold+1);
        RaycastHit[] hits=Physics.SphereCastAll(transform.position,range,Vector3.down);
        foreach(var hit in hits)
        {
            if(hit.transform.gameObject.GetComponent<Enemy_AI>()!=null)
            {
                if(nearestEnemy!=null&&hit.distance>=Vector3.Distance(nearestEnemy.transform.position,hit.transform.position))
                {
                    nearestEnemy=hit.transform.gameObject;
                }
                else
                {
                    nearestEnemy=hit.transform.gameObject;
                }
            }
        }
        
        //Debug.Log(nearestEnemy.transform.position);
        timer += Time.deltaTime;
        if(nearestEnemy!=null&&timer>=waitTime)
        {
            //transform.LookAt(nearestEnemy.transform);
            GameObject firedProjectile = Instantiate(arrow,transform.position,transform.rotation);
            var Projectile=firedProjectile.GetComponent<Projectile>();
            Projectile.target=nearestEnemy;
            Debug.Log(waitTime);
            timer=0.0f;
        }
        if(nearestEnemy==null)
        {
            nearestEnemy=gameObject;
        }
        //transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.right);
    }
}
