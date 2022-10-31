//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Enemy : MonoBehaviour
//{
//    public float maxHealth;
//    public float currentHealth;
//
//    public float damage;
//    public float speed;
//
//    private Waypoints wpoints;
//
//    private int waypointIndex;
//
//    // Start is called before the first frame update
//    void Start()
//    {
//        wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
//        currentHealth = maxHealth;
//
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        transform.position = Vector2.MoveTowards(transform.position, wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
//
//        Vector3 dir = wpoints.waypoints[waypointIndex].position - transform.position;
//        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//
//        if (Vector2.Distance(transform.position, wpoints.waypoints[waypointIndex].position) < 0.1f)
//        {
//            if (waypointIndex < wpoints.waypoints.Length - 1)
//            {
//                waypointIndex++;
//            }
//            else
//            {
//                Destroy(gameObject);
//            }
//        }
//    }
//
//    public void damageHealth()
//    {
//        if (currentHealth > 0)
//        {
//            currentHealth = currentHealth - damage;
//        }
//    }
//
//}
//