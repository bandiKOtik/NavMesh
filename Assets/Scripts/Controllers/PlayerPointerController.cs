using UnityEngine;

public class PlayerPointerController : Controller
{
    private ParticleSystem _pointerObject;
    private Character _character;

    public PlayerPointerController(Character character, ParticleSystem pointerObject)
    {
        _pointerObject = pointerObject;
        _character = character;
    }

    public override Vector3 InputDirection { get; protected set; }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("A");
        }

        _character.SetMoveDirection(InputDirection);
        _character.SetRotationDirection(InputDirection);
    }
}
