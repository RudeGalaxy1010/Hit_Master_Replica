namespace HitMasterReplica.StateMachine
{
    public class IdleTransition : Transition
    {
        private void Update()
        {
            if (Target.Health <= 0)
            {
                NeedTransit = true;
            }
        }
    }
}
