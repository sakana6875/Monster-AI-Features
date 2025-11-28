public abstract class BaseState
{
    protected Enemy enemy;

    public BaseState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
