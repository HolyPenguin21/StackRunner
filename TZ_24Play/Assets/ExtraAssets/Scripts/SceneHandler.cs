using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    SceneSettings.InputType inputType;
    SceneSettings sceneSettings;

    Scene_Input sceneInput;
    Scene_UI_Handler scene_UI_Handler;

    private ICharacter iCharacter;
    [SerializeField] private Character character;
    [SerializeField] private GameObject pickedBlockPrefab;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private ParticleSystem warpEffect_particle;
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private GameObject[] platformVariants;

    ShakeCamera shakeCamera;
    WarpEffect warpEffect;
    TrackBuilder trackBuilder;
    Effect particleManager;
    Effect scoreTextManager;

    IGameStateEvents gameStateEvents;
    ICollisionEvent collisionEvent;
    IInputEvent inputEvent;

    private void Awake()
    {
        iCharacter = character;

        sceneSettings = new SceneSettings();
        sceneSettings.Set_Framerate(40);
        inputType = sceneSettings.Get_InputType();

        gameStateEvents = new GameStateEvents();
        collisionEvent = new CollisionEvent();
        inputEvent = new InputEvent();

        sceneInput = new Scene_Input(gameStateEvents, inputEvent);
        scene_UI_Handler = new Scene_UI_Handler(gameStateEvents, collisionEvent);

        shakeCamera = new ShakeCamera(Camera.main.transform, collisionEvent, gameStateEvents, inputType);
        warpEffect = new WarpEffect(warpEffect_particle, gameStateEvents);

        particleManager = new ParticleManager(particlePrefab, iCharacter, collisionEvent);
        scoreTextManager = new ScoreTextManager(scorePrefab, iCharacter, collisionEvent);
        trackBuilder = new TrackBuilder(collisionEvent, platformVariants);
    }

    private void Start()
    {
        character.Init(pickedBlockPrefab, gameStateEvents, collisionEvent, inputEvent);

        gameStateEvents.Add_GameRestartListener(Restart);
    }

    private void Update()
    {
        sceneInput.Input_Update();
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
