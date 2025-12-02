using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _keyboardInputCharacter;
    [SerializeField] private Character _pointerInputCharacter;
    [SerializeField] private ParticleSystem particle;

    private Controller _keyboardController;
    private Controller _pointerController;

    private void Awake()
    {
        _keyboardController = new CompositController(
            new PlayerDirectionalMoveableController(_keyboardInputCharacter),
            new PlayerDirectionalRotateableController(_keyboardInputCharacter));

        _keyboardController.Enable();

        _pointerController = new PlayerPointerController(_pointerInputCharacter, particle);

        _pointerController.Enable();
    }

    private void Update()
    {
        _keyboardController.Update(Time.deltaTime);
        _pointerController.Update(Time.deltaTime);
    }
}
