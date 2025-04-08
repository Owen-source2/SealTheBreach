using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        target=GameObject.Find("King").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit, 10.0f))
        {
            agent.SetDestination(hit.point);
        }
        else
        {
            agent.SetDestination(target.position);
        }

    }
}
