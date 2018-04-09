using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : StateMachineBehaviour {

  public float verticalForce;
  private float jump_buffer_time;
  private float jump_dir;

  protected Fighter fighter;
  protected PlayerController p;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    fighter = (fighter == null) ? animator.gameObject.GetComponent<Fighter>() : fighter;
    p = fighter.GetComponentInParent<PlayerController>();
    fighter.rb.AddRelativeForce(Vector2.up * verticalForce * p.vDir);
    jump_buffer_time = PlayerController.MAX_JUMP_TIME;
    jump_dir = p.hDir;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    jump_buffer_time -=Time.deltaTime;
    fighter.rb.AddRelativeForce(Vector2.up * (verticalForce / 4) * p.vDir);
    fighter.rb.AddRelativeForce(Vector2.right * PlayerController.AIR_SPEED * jump_dir);


    if (jump_buffer_time <= 0 || p.vDir < 1) {
      animator.SetBool("JUMP", false);
      animator.SetBool("FALLING", true);
    }

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    jump_buffer_time = 0f;
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
