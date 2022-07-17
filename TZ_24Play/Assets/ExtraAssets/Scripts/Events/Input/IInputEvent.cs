
public interface IInputEvent 
{
    delegate void OnInput(float delta);

    public void Add_OnInput_Listener(OnInput method);
    public void Invoke_OnInput(float delta);
    public void Remove_Listeners();
}
