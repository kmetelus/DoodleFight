using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  // Character Movement Variabeles
  // Movement Speed
  private const float DASH_SPEED = 0.125f;
  private const float WALK_SPEED = 3f;

  private float dash_buffer_time = 0.5f; // Amount of dash time
  private float dtp = 0f; // counter for number of taps for dash
  private bool dash = false;
  private float dashDir = 1f;

  // Jumping Variables
  public bool grounded = true;
  private const float FALL_MULTIPLIER = 1f;
  private const float LOW_JUMP_MULTIPLIER = 2f;
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
      float hDir = Input.GetAxis ("HMovement");

      //Store vertical movement input direction
      float vDir = Input.GetAxis ("VMovement");

      float x = gameObject.transform.position.x;
      float y = gameObject.transform.position.y;
      float z = gameObject.transform.position.z;

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
        gameObject.transform.position = new Vector3(x + (DASH_SPEED * dashDir), y, z);
      } else {
        // gameObject.transform.position = new Vector3(x + (WALK_SPEED * hDir), y, z);
        rb.AddForce((Vector2.right * WALK_SPEED) * hDir);
        Debug.Log((Vector2.right * WALK_SPEED) * hDir);
      }

      // Jump Handling
      if (vDir < 0) {
          Debug.Log("1");
          rb.gravityScale = LOW_JUMP_MULTIPLIER;
          djpt = 0f;
      } else if (vDir > 0 && djpt < JUMP_TIME) {
        Debug.Log("2");
          rb.gravityScale = JUMP_RESIST;
          // gameObject.transform.position = new Vector3(x + (WALK_SPEED * hDir), y * (1.5f * (JUMP_TIME - djpt)), z);
          rb.AddForce(Vector2.up * 25f);
          djpt += Time.deltaTime;
      } else if (vDir > 0 && djpt > JUMP_TIME) {
          Debug.Log("3");
          gameObject.transform.position = new Vector3(x + (WALK_SPEED * hDir), y, z);
          rb.gravityScale = FALL_MULTIPLIER;
      } else {
          // Debug.Log("4");
          djpt = 0f;
          rb.gravityScale = 1f;
      }
    }
}
