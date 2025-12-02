using UnityEngine;

public class KeyboardController : Controller
{
    private Character _character;

    public KeyboardController(Character character)
    {
        _character = character;
    }

    public override Vector3 InputDirection { get; protected set; }

    protected override void UpdateLogic(float deltaTime)
    {
        InputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _character.SetMoveDirection(InputDirection);
        _character.SetRotationDirection(InputDirection);
    }
}