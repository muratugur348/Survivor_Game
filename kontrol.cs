using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrol : StateMachineBehaviour
{
    private oyunKontrol oKontrol;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oKontrol = GameObject.Find("_Scripts").GetComponent<oyunKontrol>();
    }
}
