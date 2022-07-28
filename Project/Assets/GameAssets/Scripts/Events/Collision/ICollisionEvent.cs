
public interface ICollisionEvent
{
    delegate void OnWallPass();
    delegate void OnWallCollision();
    delegate void OnPickUp();

    public void Add_OnWallPass_Listener(OnWallPass method);
    public void Invoke_OnWallPass();

    public void Add_OnWallCollision_Listener(OnWallCollision method);
    public void Invoke_OnWallCollision();

    public void Add_OnPickUp_Listener(OnPickUp method);
    public void Invoke_OnPickUp();

    public void Remove_Listeners();
}
