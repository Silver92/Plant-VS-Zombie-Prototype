using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        projectileParent = GameObject.Find("Projectiles");
        
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
        print(myLaneSpawner);
    }

    private void Update()
    {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("IsAttacking", true);
        } else {
            animator.SetBool("IsAttacking", false);
        }
    }
    
    void SetMyLaneSpawner () {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        
        foreach (Spawner spawner in spawnerArray) {
            if (spawner.transform.position.y == transform.position.y) {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + "can't find spawner in lane");
    }
    
    bool IsAttackerAheadInLane() {
        
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }
        
        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        return false;
    }

    public void Fire () {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
