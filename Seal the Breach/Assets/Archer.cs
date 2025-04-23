using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Archer : MonoBehaviour
{
    [SerializeField]float range = 200.0f;
    [SerializeField]GameObject arrow;
    //[SerializeField]GameObject scoreboard;
    public GameObject nearestEnemy;
    [SerializeField]GameObject dummy;
    float timer=0.0f;
    [SerializeField]float waitTimeInit=15.0f;
    LayerMask enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = LayerMask.GetMask("Enemy");
        //nearestEnemy=gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        //float waitTime=waitTimeInit*10/(scoreboard.GetComponent<TrackResources>().gold+1);
        RaycastHit[] hits=Physics.SphereCastAll(transform.position,range,Vector3.one,Mathf.Infinity,enemies);
        foreach(var hit in hits)
        {
            if(nearestEnemy==null)
            {
                nearestEnemy=dummy;
            }
            if(Vector3.Distance(hit.transform.position,transform.position)<Vector3.Distance(nearestEnemy.transform.position,transform.position))
            {
                nearestEnemy=hit.transform.gameObject;
            }
        }
        
        //Debug.Log(nearestEnemy.transform.position);
        timer += Time.deltaTime;
        if(nearestEnemy!=null&&timer>=waitTimeInit)
        {
            //transform.LookAt(nearestEnemy.transform);
            GameObject firedProjectile = Instantiate(arrow,transform.position,transform.rotation);
            var Projectile=firedProjectile.GetComponent<Projectile>();
            Projectile.target=nearestEnemy;
            timer=0.0f;
        }
        if(nearestEnemy==null)
        {
            //nearestEnemy=gameObject;
        }
        //transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.right);
    }
    void OnDrawGizmos()
    {
        //if(Physics.SphereCastAll(transform.position,range,Vector3.zero,Mathf.Infinity,enemies))
        //{
            //Gizmos.DrawWireSphere(transform.position,range);
        //}
    }
}
