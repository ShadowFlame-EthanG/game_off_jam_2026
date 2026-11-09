using UnityEngine;
using UnityEngine.InputSystem;

public class PedalRotation : MonoBehaviour
{
    private Animator mAnimator;
    InputAction move;
    InputAction brake;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        if (InputSystem.actions) {
            move = InputSystem.actions.FindAction("Player/Move");
            brake = InputSystem.actions.FindAction("Player/Brake");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = move.ReadValue<Vector2>();
        if (mAnimator != null) {
            if (moveValue[1] > 0.0) {
                mAnimator.SetBool("Resting", false);
                mAnimator.SetBool("Backward", false);
                mAnimator.SetBool("Forward", true);
                Debug.Log("Forward!");
            }

            else if (moveValue[1] < 0.0) {
                mAnimator.SetBool("Resting", false);
                mAnimator.SetBool("Backward", true);
                mAnimator.SetBool("Forward", false);
                Debug.Log("Backwards!");
            }

            else {
                mAnimator.SetBool("Resting", true);
                mAnimator.SetBool("Backward", false);
                mAnimator.SetBool("Forward", false);
                Debug.Log("Resting!");
            }
        }
    }
}
