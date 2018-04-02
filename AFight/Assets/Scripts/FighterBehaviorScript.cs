using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBehaviorScript : StateMachineBehaviour {

  public float horizontalForce;
  public float verticalForce;

  protected Fighter fighter;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    // Debug.Log(stateInfo.length);
    Debug.Log("HEERE");
	  fighter = (fighter == null) ? animator.gameObject.GetComponent<Fighter>() : fighter;
    PlayerController p = fighter.GetComponentInParent<PlayerController>();
    fighter.rb.AddRelativeForce(Vector2.up * verticalForce * p.vDir);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    PlayerController p = fighter.GetComponentInParent<PlayerController>();
    // Debug.Log("HEREROIEJROEIFJ");
    fighter.rb.AddRelativeForce(Vector2.right * horizontalForce * p.hDir);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
