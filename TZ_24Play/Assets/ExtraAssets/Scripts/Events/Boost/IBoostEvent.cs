
public interface IBoostEvent
{
    delegate void OnBoost();

    public void Add_OnBoost_Listener(OnBoost method);
    public void Invoke_OnBoost();
    public void Remove_Listeners();
}
