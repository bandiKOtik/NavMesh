using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _keyboardInputCharacter;

    private Controller _keyboardController;

    private void Awake()
    {
        _keyboardController = new CompositController(
            new PlayerDirectionalMoveableController(_keyboardInputCharacter),
            new PlayerDirectionalRotateableController(_keyboardInputCharacter));

        _keyboardController.Enable();
    }

    private void Update()
    {
        _keyboardController.Update(Time.deltaTime);
    }
}
