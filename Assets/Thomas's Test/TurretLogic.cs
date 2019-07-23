﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogic : MonoBehaviour
{

    public GameObject[] waypoints;
    int myCurrentWaypoint;
    private int nextWaypoint;
    public GameObject myProjectile;
    public bool isMoving;
    public float WaitTime = 1.0f;
    public bool run = false;
    float speed;
    BossStats myStats;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        myCurrentWaypoint = 0;
        myStats = GetComponentInParent<BossStats>();
        speed = 0.15f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(myStats.health <= 80)
        {
            speed = 0.18f;
        }

        if (myStats.health <= 60)
        {
            speed = 0.21f;
        }

        if (myStats.health <= 40)
        {
            speed = 0.24f;
        }

        if (myStats.health <= 20)
        {
            speed = 0.27f;
        }


    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            run = false;
            MoveToWaypoint();
        }

        

        if(isMoving == false)
        {
            if(!run)
            StartCoroutine(Fire());
            //shootProjectile();
        }
    }

    void MoveToWaypoint()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[myCurrentWaypoint].transform.position, speed);

        if (transform.position == waypoints[myCurrentWaypoint].transform.position)
        {
            isMoving = false;
            nextWaypoint = Random.Range(0, waypoints.Length);

            if (nextWaypoint == myCurrentWaypoint)
            {
                nextWaypoint = Random.Range(0, waypoints.Length);
            }

            myCurrentWaypoint = nextWaypoint;
        }

    }

    public IEnumerator Fire()
    {
        run = true;
        yield return new WaitForSeconds(3);
        shootProjectile();
        yield return new WaitForSeconds(1);
        isMoving = true;
    }
   


    void shootProjectile()
    {
        GameObject newProjectile = Instantiate(myProjectile, this.transform.position, this.transform.rotation);

       
    }
    
}
