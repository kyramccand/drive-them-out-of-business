using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Traffic_NPC_Patrol : MonoBehaviour {
       // private Animator anim;
       public float speed = 5f;
       private float waitTime;
       public float startWaitTime = 0;
       public float turnSpeed = 1000f;

       public Transform[] moveSpots;
       public int startSpot = 0;

       // Turning
       private int nextSpot;
       private int previousSpot;
       public bool faceRight = false;

       void Start(){
              // transform.rotation = Quaternion.Euler(0f, 0f, 180f);
              waitTime = startWaitTime;
              nextSpot = startSpot;
       }

       void Update(){
              transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f){
                     if (waitTime <= 0){
                            previousSpot = nextSpot;
                            if (nextSpot == (moveSpots.Length - 1)) {
                                nextSpot = 0;
                            }
                            else {
                                nextSpot += 1;
                            }
                            waitTime = startWaitTime;
                     } else {
                            waitTime -= Time.deltaTime;
                            
                     }
              }
              else {
                     updateRotation();
              }
       }

       void updateRotation() {
              // https://discussions.unity.com/t/rotating-slowly-toward-a-target-while-also-moving-toward-that-target/886726
              Vector3 targetPos = moveSpots[nextSpot].transform.position;
              float angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg;
              Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
              transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed);
       }
}