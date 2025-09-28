using UnityEngine;

public class Run : MovmentBase
{
    private bool isRunning = false;
    private float moveInput;

    [SerializeField] private Movement movment;
    [SerializeField] private float runSpeedMultiplier;

    public override bool WantsControl => isRunning && moveInput != 0;

    public override int Priority => 2;

    public override void ActionLogic()
    {
        if (isRunning && moveInput != 0)
        {
            rb.linearVelocity = new Vector2(movment.Speed * runSpeedMultiplier * moveInput, rb.linearVelocity.y); 
        }
        
    }

    public override void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        isRunning = dashPressed;
        this.moveInput = moveInput;
    }
}
