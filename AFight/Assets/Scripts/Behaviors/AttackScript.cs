using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : StateMachineBehaviour {

  public float movementForward;
  protected Fighter fighter;
  protected PlayerController p;
  protected AnimationScript a;
  protected HitboxManagerScript h;
  private HitboxManagerScript.hitBoxes b;
  private float frames;
  public float direction;

  // public enum hitBoxes { frame1Box, frame2Box, clear }

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    fighter = (fighter == null) ? animator.gameObject.GetComponent<Fighter>() : fighter;
    p = fighter.GetComponentInParent<PlayerController>();
    a = fighter.GetComponentInParent<AnimationScript>();
    h = fighter.GetComponentInParent<HitboxManagerScript>();
    Debug.Log(stateInfo.IsName("Attack1"));

    b = (stateInfo.IsName("Attack1") || stateInfo.IsName("AerialAttack")) ? HitboxManagerScript.hitBoxes.frame1Box :
    (stateInfo.IsName("Attack2")) ? HitboxManagerScript.hitBoxes.frame2Box :
    (stateInfo.IsName("Attack3")) ? HitboxManagerScript.hitBoxes.frame3Box : HitboxManagerScript.hitBoxes.frame4Box;

    fighter.attackState = stateInfo.IsName("Attack1") || stateInfo.IsName("Attack2");
    fighter.finalAttackState =  stateInfo.IsName("Attack3") || stateInfo.IsName("AerialAttack");
    fighter.specialState = stateInfo.IsName("Special");
    frames = 0;
    direction = p.dashDir;

    fighter.current_meter += (stateInfo.IsName("Special")) ? -25f : 2.5f;
    a.canFlip = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	  fighter.rb.AddRelativeForce(Vector2.right * movementForward * direction);
    p.vDir = direction;
    // Debug.Log(frames);
    frames++;
    if (frames > 10) {
      h.setHitBox(b);
    } else {
      h.resetHitBox();
    }
    if (frames > AnimationScript.MAX_FRAMES && (stateInfo.IsName("Attack3"))) {
      animator.SetBool("ATTACK1", false);
      p.resetAttack = false;
    }
    if (frames > AnimationScript.MAX_FRAMES && ( stateInfo.IsName("Special"))) {
      animator.SetBool("SPECIAL", false);
      p.resetAttack = false;
    }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      h.setHitBox(HitboxManagerScript.hitBoxes.clear);
      if (stateInfo.IsName("Attack3") || stateInfo.IsName("Special")) {
        p.resetAttack = true;
      }
      fighter.attackState = fighter.finalAttackState = fighter.specialState = false;
      // h.resetHitBox();
      // Debug.Log("Yup");
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
