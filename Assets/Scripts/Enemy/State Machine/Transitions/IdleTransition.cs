namespace HitMasterReplica.StateMachine
{
    public class IdleTransition : EnemyTransition
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
