
public class InputEvent : IInputEvent
{
    event IInputEvent.OnInput onInput;

    public void Add_OnInput_Listener(IInputEvent.OnInput method)
    {
        onInput += method;
    }

    public void Invoke_OnInput(float delta)
    {
        onInput?.Invoke(delta);
    }

    public void Remove_Listeners()
    {
        onInput = null;
    }
}
