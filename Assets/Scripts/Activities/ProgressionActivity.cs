public sealed class ProgressionActivity : Activity
{
    public ProgressionActivity(ActivityData data) 
        : base(data) { }

    public override void Run()
    {
        base.Run();

        ReferenceManager.Instance.ActivitiesManager.RemoveActivity(this);
        ReferenceManager.Instance.UnlockManager.LockActivity(this);
    }
}
