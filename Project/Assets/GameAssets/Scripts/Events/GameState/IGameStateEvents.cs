
public interface IGameStateEvents
{
    delegate void OnGameStart();
    delegate void OnGameEnd();
    delegate void OnGameRestart();

    public void Add_GameStartListener(OnGameStart method);
    public void Invoke_GameStart();

    public void Add_GameEndListener(OnGameEnd method);
    public void Invoke_GameEnd();

    public void Add_GameRestartListener(OnGameRestart method);
    public void Invoke_GameRestart();

    public void Remove_Listeners();
}
