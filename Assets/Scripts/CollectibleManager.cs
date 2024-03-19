using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public Animator anim;

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 0.3f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, this.transform.position) < 0.5f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, waypoints[currentWaypointIndex].transform.position.y), Time.deltaTime * speed);
    }

    public void DestroyCollectible() 
    {
        Destroy(this.gameObject);
    }   
}
