using UnityEngine;

public class PlayerDirectionalMoveableController : Controller
{
    private IDirectionMoveable _moveable;
    public override Vector3 InputDirection { get; protected set; }

    public PlayerDirectionalMoveableController(IDirectionMoveable moveable)
    {
        _moveable = moveable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        InputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _moveable.SetMoveDirection(InputDirection);
    }
}