using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    public class DieState : State
    {
        private void OnEnable()
        {
            Destroy(gameObject, 0.7f);
        }
    }
}
