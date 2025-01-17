﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestShieldLogic : MonoBehaviour
{   
    public OrbType targetType;
    TestDeviceLogic charge;
    private ParticleSystem onHitEmit;

    // Start is called before the first frame update
    void Start()
    {
        charge = GetComponentInParent<TestDeviceLogic>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.GetComponent<ProjectileActions>())
        {
            if(coll.GetComponent<ProjectileActions>().type == targetType)
            {
                onHitEmit = GetComponentInChildren<ParticleSystem>();
                onHitEmit.Emit(10);
                charge.GainCharge(20);
                Destroy(coll.gameObject);
            }
            else
            {
                charge.LoseCharge(-20);
                Destroy(coll.gameObject);
            }
        }   
    }
}
