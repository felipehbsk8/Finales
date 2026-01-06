using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = -9.81f;


    private CharacterController _characterController;
    private PlayerModel _model;
    private PlayerView _view;
    private PlayerShooting _playerShooting;

    private Vector3 _position;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _view = GetComponentInChildren<PlayerView>();
        _playerShooting = GetComponent<PlayerShooting>();

        _model = new PlayerModel(100, 100);
    }
    private void Update()
    {
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            StartCoroutine(TryCast());
        if(Input.GetKeyDown(KeyCode.R))
            _model.RegenMana(10);
    }

    private void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        _characterController.Move(move * _moveSpeed * Time.deltaTime);

        _view.SetMovement(h, v);

        if (_characterController.isGrounded && _position.y < 0)
            _position.y = -2f;

        _position.y += _gravity * Time.deltaTime;
        _characterController.Move(_position * Time.deltaTime);
    }

    private IEnumerator TryCast()
    {
        if (_model.CanCast(10))
        {
            _moveSpeed = 0;
            _model.SpendMana(10);
            _view.PlayCastAnim();
            _playerShooting.Shoot();
            yield return new WaitForSecondsRealtime(0.5f);
            _moveSpeed = 5; //Ajustar el timing
        }
    }
}
