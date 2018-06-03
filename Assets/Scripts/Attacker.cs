using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;
        
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            animator.SetBool("IsAttacking", false);
        }
	}

    private void OnTriggerEnter2D() {
    
    }
    
    public void SetSpeed (float speed) {
        currentSpeed = speed;
    }
    
    public void StrikeCurrentTarget (float damage) {
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if(health) {
                health.DealDamage(damage);
            }
        }
        
    }
    
    public void Attack( GameObject obj) {
        currentTarget = obj;
    }
}
