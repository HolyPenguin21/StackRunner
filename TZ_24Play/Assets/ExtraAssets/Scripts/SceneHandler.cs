using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    SceneSettings.InputType inputType;
    SceneSettings sceneSettings;

    [SerializeField] private Character character;
    [SerializeField] private GameObject pickedBlockPrefab;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private ParticleSystem warpEffect_particle;
    [SerializeField] private Canvas scorePrefab;
    [SerializeField] private GameObject[] platformVariants;

    Scene_UI_Handler scene_UI_Handler;
    ShakeCamera shakeCamera;
    WarpEffect warpEffect;

    ParticleManager particleManager;
    ScoreTextManager scoreTextManager;
    TrackBuilder trackBuilder;
    Scene_Input sceneInput;

    IGameStateEvents gameStateEvents;
    ICollisionEvent collisionEvent;
    IInputEvent inputEvent;

    private void Awake()
    {
        sceneSettings = new SceneSettings();
        sceneSettings.Set_Framerate(40);
        inputType = sceneSettings.Get_InputType();

        gameStateEvents = new GameStateEvents();
        collisionEvent = new CollisionEvent();
        inputEvent = new InputEvent();

        scene_UI_Handler = new Scene_UI_Handler(gameStateEvents, collisionEvent);
        shakeCamera = new ShakeCamera(Camera.main.transform, collisionEvent, gameStateEvents, inputType);
        warpEffect = new WarpEffect(warpEffect_particle, gameStateEvents);

        particleManager = new ParticleManager(particlePrefab, character, collisionEvent);
        scoreTextManager = new ScoreTextManager(scorePrefab, character, collisionEvent);
        trackBuilder = new TrackBuilder(collisionEvent, platformVariants);
        sceneInput = new Scene_Input(gameStateEvents, inputEvent);

        gameStateEvents.Add_GameRestartListener(Restart);
    }

    private void Start()
    {
        character.Init(pickedBlockPrefab, gameStateEvents, collisionEvent, inputEvent);
    }

    private void Update()
    {
        sceneInput.SceneInput();
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        gameStateEvents.Remove_Listeners();
        collisionEvent.Remove_Listeners();
        inputEvent.Remove_Listeners();
    }
}
