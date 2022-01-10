using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //public float moveSpeed;
    //public Rigidbody theRB;
    private bool chasing;
    public float distanceToChase = 10f, distanceToLose = 15f, distanceToStop = 2f;

    public NavMeshAgent agent;

    private Vector3 targetPoint, startPoint;

    public float keepChasingTime;
    private float chaseCounter;

    public GameObject bullet;
    public Transform firePoint;

    public float fireRate;
    private float fireCount;



    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                chasing = true;
                fireCount = 1f;
            }
            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;

                if (chaseCounter <= 0)
                {
                    agent.destination = startPoint;
                }
            }
        }
        else
        {
            //transform.LookAt(targetPoint);

            //theRB.velocity = transform.forward * moveSpeed;

            if(Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {
                agent.destination = targetPoint;
            }
            else
            {
                agent.destination = transform.position;
            }
            
            if (Vector3.Distance(transform.position, targetPoint) > distanceToLose)
            {
                chasing = false;

                chaseCounter = keepChasingTime;
            }
            fireCount-= Time.deltaTime;

            if(fireCount <= 0)
            {
                fireCount = fireRate;

                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }

        }
    }
}
