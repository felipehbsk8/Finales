using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetMovement(float x, float y)
    {
        _animator.SetFloat("xSpeed", x, 0.1f, Time.deltaTime);
        _animator.SetFloat("ySpeed", y, 0.1f, Time.deltaTime);
    }

    public void PlayCastAnim()
    {
        _animator.SetTrigger("Throw");
    }
}
