﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    protected CharacterAnimation enemyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    protected Transform playerTarget;

    public float attack_Distance = 1f;
    public float chase_Player_After_Attack = 1f;

    protected float current_Attack_Time;
    public float default_Attack_Time = 2f;

    protected bool followPlayer, attackPlayer;

    public bool isMelee;

    public GameObject childObject;

    void Awake() {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    
    void Start() {
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }

    
    void Update() {

        if (playerTarget)
        {
            transform.LookAt(playerTarget);
            childObject.transform.localRotation = Quaternion.identity;

            Attack();
        }
        
    }

    void FixedUpdate() {
        if (playerTarget)
            FollowTarget();
    }

    void FollowTarget() {

        
        if (!followPlayer)
            return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance) {
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0) {
                enemyAnim.Walk(true);   
            }


        } else if(Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance) {

            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;

        }

    } 

    protected virtual void Attack() {

        
        if (!attackPlayer)
            return;

        current_Attack_Time += Time.deltaTime;

        if(current_Attack_Time > default_Attack_Time) {

            if (isMelee)
                enemyAnim.EnemyAttack(Random.Range(0, 3)); 
            else
                enemyAnim.EnemyAttack(3); 

            current_Attack_Time = 0f;

        }

        if(Vector3.Distance(transform.position, playerTarget.position) >
                attack_Distance + chase_Player_After_Attack) {

            attackPlayer = false;
            followPlayer = true;
        
        }

    } 

} 



































