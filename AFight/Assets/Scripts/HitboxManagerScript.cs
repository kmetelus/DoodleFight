﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManagerScript : MonoBehaviour {
  // Set these in the editor
  public PolygonCollider2D frame1;
  public PolygonCollider2D frame2;
  public PolygonCollider2D frame3;

  // Used for organization
  private PolygonCollider2D[] colliders;

  // Collider on this game object
  private PolygonCollider2D localCollider;

  // We say box, but we're still using polygons.
  public enum hitBoxes { frame1Box, frame2Box, frame3Box, clear }// special case to remove all boxes


  void Start() {
      // Set up an array so our script can more easily set up the hit boxes
      colliders = new PolygonCollider2D[]{frame1, frame2, frame3};

      // Create a polygon collider
      localCollider = gameObject.GetComponent<PolygonCollider2D>();
      localCollider.pathCount = 0; // Clear auto-generated polygons
  }

  void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.CompareTag("Test")) {
        Debug.Log("THATS A HIT");
    }
  }

  public void resetHitBox() {
    localCollider.pathCount = 0;
  }

  public void setHitBox(hitBoxes val) {
      if (val != hitBoxes.clear) {
          // Debug.Log("HI");
          localCollider.SetPath(0, colliders[(int)val].GetPath(0));
          return;
      }
      resetHitBox();
  }
}
