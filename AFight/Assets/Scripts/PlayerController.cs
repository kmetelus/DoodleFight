using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  // Character Movement Variabeles
  // Movement Speed
  private const float DASH_SPEED = 0.15f;
  private const float WALK_SPEED = 0.065f;

  private float dash_buffer_time = 0.5f; // Amount of dash time
  private float dtp = 0f; // counter for number of taps for dash
  private bool dash = false;

  // Jumping Variables
  private const float FALL_MULTIPLIER = 2.5f;
  private const float LOW_JUMP_MULTIPLIER = 2f;

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
            dash = true;
          } else {
            dash_buffer_time = 0.5f;
            dtp += 1;
          }
      }

      if (dash_buffer_time > 0) {
        dash_buffer_time -= Time.deltaTime;
      } else {
        dtp = 0;
        dash = false;
      }

      if (dash) {
        gameObject.transform.position = new Vector3(x + (DASH_SPEED * hDir), y, z);
      } else {
        gameObject.transform.position = new Vector3(x + (WALK_SPEED * hDir), y, z);
      }

      // Jump Handling
      if (vDir < 0) {
          // rb.gravityScale = FALL_MULTIPLIER;
      } else if (vDir > 0) {
          rb.AddForce(gameObject.transform.up * 7f);
          gameObject.transform.position = new Vector3(x + (WALK_SPEED * hDir), y * 0.7f, z);
          rb.gravityScale = LOW_JUMP_MULTIPLIER;
      } else {
        Debug.Log("Heaaoo");
          // rb.gravityScale = 1f;
      }
    }
}
