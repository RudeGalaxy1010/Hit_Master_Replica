namespace HitMasterReplica.StateMachine
{
    public class DieTransition : EnemyTransition
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
