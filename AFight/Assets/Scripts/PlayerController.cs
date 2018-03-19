using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  // Character Movement Variabeles
  // Movement Speed
  private const float DASH_PUSH = 0.1f;
  private const float DASH_SPEED = 5f;
  private const float WALK_SPEED = 2f;
  private const float ACCELERATION = 10f;

  private float dash_buffer_time = 0.5f; // Amount of dash time
  private float dtp = 0f; // counter for number of taps for dash
  private bool dash = false;
  private float dashDir = 1f;

  // Jumping Variables
  public bool grounded = true;
  private const float FALL_MULTIPLIER = 2f;
  private const float FAST_FALL_MULTIPLIER = 10f;
  private const float JUMP_RESIST = 1f;
  private const float JUMP_TIME = 0.5f;  // max jump time
  private float djpt = 0f; // time spent jumping

  private Rigidbody2D rb;

  // Use this for initialization
  void Start()  {
      rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()  {

      //Store horizontal movement input direction
      float hDir = Input.GetAxis("HMovement");

      //Store vertical movement input direction
      float vDir = Input.GetAxis("VMovement");

      // float x = gameObject.transform.position.x;
      // float y = gameObject.transform.position.y;
      // float z = gameObject.transform.position.z;

      // Movement and Dash Handling
      if (Input.GetButtonDown("HMovement")) {
          if (dash_buffer_time > 0 && dtp == 1) {
            dashDir = !dash ? hDir : dashDir; // Set the dash direction
            dash = true;
          } else {
            dash_buffer_time = 0.5f;
            dtp += 1;
          }
      }

      if (dash_buffer_time > 0) {
        dash_buffer_time -= Time.deltaTime;  // Allow dash for 0.5s (dash_buffer_time)
      } else {
        dtp = 0;
        dash = false;
      }

      if (dash) {
        // gameObject.transform.position = new Vector3(x + (DASH_PUSH * dashDir), y, z);
        rb.velocity =  rb.velocity.normalized * DASH_SPEED;
      } else {
        // Debug.Log((Vector2.right * WALK_SPEED) * hDir);
        Vector2 horizontalMovement = new Vector2(hDir, 0);
        rb.AddForce((Vector2.right * WALK_SPEED) * hDir * ACCELERATION);
        rb.AddForce(horizontalMovement * WALK_SPEED);
        rb.velocity = (rb.velocity.magnitude > WALK_SPEED) ? rb.velocity.normalized * WALK_SPEED : rb.velocity;
      }

/*
*
* Jump Handling
*
*/
      djpt = (grounded) ? 0 : djpt;

      if (vDir < 0) {
          // Debug.Log("1");
          rb.gravityScale = FAST_FALL_MULTIPLIER;
      } else if (vDir > 0 && djpt < JUMP_TIME) {
        // Debug.Log("2");
          rb.gravityScale = FALL_MULTIPLIER;
          rb.gravityScale = JUMP_RESIST;
          // rb.velocity = new Vector3(0, 2, 0);

          rb.AddForce(Vector2.up * 50f);
          djpt += Time.deltaTime;
      } else if (vDir > 0 && djpt > JUMP_TIME) {
          // Debug.Log("3");
          rb.gravityScale = FALL_MULTIPLIER;
      } else {
          // Debug.Log("4");
          // djpt =  0f;
          rb.gravityScale = (rb.gravityScale == FAST_FALL_MULTIPLIER) ? FAST_FALL_MULTIPLIER : FALL_MULTIPLIER;
      }
    }
}
