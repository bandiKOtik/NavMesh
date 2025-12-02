using UnityEngine;

public class PlayerDirectionalRotateableController : Controller
{
    private IDirectionRotateable _rotateable;
    public override Vector3 InputDirection { get; protected set; }

    public PlayerDirectionalRotateableController(IDirectionRotateable rotateable)
    {
        _rotateable = rotateable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        InputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _rotateable.SetRotationDirection(InputDirection);
    }
}