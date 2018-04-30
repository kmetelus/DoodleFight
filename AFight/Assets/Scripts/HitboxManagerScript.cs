using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManagerScript : MonoBehaviour {
  // Set these in the editor
  public PolygonCollider2D frame1;
  public PolygonCollider2D frame2;
  public PolygonCollider2D frame3;
  public PolygonCollider2D frame4;

  // Used for organization
  private PolygonCollider2D[] colliders;

  // Collider on this game object
  private PolygonCollider2D localCollider;

  private Fighter f;
  private PlayerController p;

  // We say box, but we're still using polygons.
  public enum hitBoxes { frame1Box, frame2Box, frame3Box, frame4Box, clear }// special case to remove all boxes


  void Start() {
      // Set up an array so our script can more easily set up the hit boxes
      colliders = new PolygonCollider2D[]{frame1, frame2, frame3, frame4};
      f = gameObject.GetComponentInParent<Fighter>();
      p = gameObject.GetComponentInParent<PlayerController>();
      // Create a polygon collider
      localCollider = gameObject.GetComponent<PolygonCollider2D>();
      localCollider.pathCount = 0; // Clear auto-generated polygons
  }

  void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2")) {
        // Debug.Log("THATS A HIT");
        Fighter opp = col.gameObject.GetComponentInParent<Fighter>();
        PlayerController opc = col.gameObject.GetComponentInParent<PlayerController>();
        if (opp.hittable && (f.attackState || f.finalAttackState || f.specialState)) {
          if (f.attackState) {
            opp.takeDamage(5f, 100f, 50f, p.dashDir, opc.defending);
          } else if(f.finalAttackState) {
            opp.takeDamage(10f, 1000f, 100f, p.dashDir, opc.defending);
          } else {
            opp.takeDamage(10f, 0f, 300f, p.dashDir, false);
          }
          f.current_meter += 2.5f;
        }
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
