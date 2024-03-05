using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RageEnemyController : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private float speed = 1f;

    [SerializeField] private GameObject player;

    private bool canWalk = false;
    private bool ragingMode = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, player.transform.position) < 14f && !ragingMode)
        {
            anim.SetBool("makeRage", true);
            ragingMode = true;
            Invoke("StartWalk", 1.26f);
        }

        if (canWalk)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, this.transform.position) < 1f)
            {
                currentWaypointIndex++;
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                    transform.rotation = Quaternion.identity;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(waypoints[currentWaypointIndex].transform.position.x, transform.position.y), Time.deltaTime * speed);
        }
        
    }

    private void StartWalk()
    {
        canWalk = true;
    }
}
