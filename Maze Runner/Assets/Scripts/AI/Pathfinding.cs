using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pathfinding
{
    public class Pathfinding : MonoBehaviour
    {
        public Transform playerPosition;
        private NavMeshAgent nav;
        public Animator anim;
        private float speed = 0f; 

        private void Start() 
        {
            nav = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            FindPlayer();
        } 
        
        private void FixedUpdate() 
        {
            FindPlayer();
            speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;
            if(nav.remainingDistance > 50f)
                Idle();

            if(nav.remainingDistance > 3f && nav.remainingDistance < 50f)
                Sprint();

            if(nav.remainingDistance < 3f && nav.remainingDistance > 1f)
                Walk();

            if(nav.remainingDistance < 1f)
                Attack();

            if (!nav.pathPending && nav.remainingDistance < 0.5f) 
                FindPlayer();
        }

        private void Sprint()
        {
            anim.Play("mutant run", 0, speed);
            nav.speed = 16f;
        }

        private void Walk()
        {
            anim.Play("mutant walk", 0, speed);
            nav.speed = 2f;
        
        }

        private void Attack()
        {
            anim.Play("mutant swing");
            nav.speed = 0f;
        }

        private void Idle()
        {
            anim.Play("mutant idle");
            nav.speed = 0f;
        }

        public void FindPlayer()
        {
            nav.destination = playerPosition.position;
        }
    }
}

