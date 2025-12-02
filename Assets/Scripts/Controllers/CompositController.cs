using UnityEngine;

public class CompositController : Controller
{
    [SerializeField] private Controller[] _controllers;

    public CompositController(params Controller[] controllers)
    {
        _controllers = controllers;
    }

    public override Vector3 InputDirection { get; protected set; }

    public override void Enable()
    {
        base.Enable();

        foreach (var controller in _controllers)
            controller.Enable();
    }

    public override void Disable()
    {
        base.Disable();

        foreach (var controller in _controllers)
            controller.Disable();
    }

    protected override void UpdateLogic(float deltaTime)
    {
        foreach (var controller in _controllers)
            controller.Update(deltaTime);
    }
}
