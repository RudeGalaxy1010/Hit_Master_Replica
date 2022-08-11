namespace HitMasterReplica.StateMachine
{
    public class DieTransition : Transition
    {
        private void Update()
        {
            if (Enemy.Health <= 0)
            {
                NeedTransit = true;
            }
        }
    }
}
