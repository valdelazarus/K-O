using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ShootingBehaviour : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponentInParent<Player2Attack>().isShooting = false;
    }

 
}
