public sealed class ActionActivity : Activity
{
    public ActionActivity(ActivityData data) 
        : base(data) { }

    public override void Run()
    {
        base.Run();

        //This will cause activity to exit active state on a next Run()
        ReferenceManager.Instance.ActivitiesManager.StopActivity(this);
    }
}
