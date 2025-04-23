using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public GameObject bloodParticles;

    GameObject gate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        target=GameObject.Find("Castlev2/Portcullis").transform;
        gate=GameObject.Find("Castlev2/Portcullis");
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit, 10.0f))
        {
            if(hit.transform.gameObject.GetComponent<Gate>())
            {
                gate.GetComponent<Gate>().TakeDamage();
            }
        }
        else
        {
            agent.SetDestination(target.position);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Projectile>()!=null)
        {
            Instantiate(bloodParticles,transform);
            Debug.Log("died");
            Destroy(gameObject);
        }
    }
}
