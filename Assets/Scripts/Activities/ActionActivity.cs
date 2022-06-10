public sealed class ActionActivity : Activity
{
    public ActionActivity(ActivityData data) : base(data)
    {
    }

    public override void Run()
    {
        base.Run();

        ActivitiesManager.Instance.StopActivity(this);
    }
}
