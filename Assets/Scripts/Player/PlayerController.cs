using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _currentSpeed;

    [Header("References")]
    [SerializeField] private Transform _oriantationTransform;

    [Header("Jump Settings")]
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    private bool _canJump = true;

    [Header("Layer Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayDistance = 0.35f;

    [Header("Run & Energy Settings")]
    [SerializeField] private KeyCode _runKey = KeyCode.LeftShift;
    [SerializeField] private float _runMultiplier = 1.5f;
    [SerializeField] private float _maxEnergyDuration = 4f;        
    [SerializeField] private float _energyRechargeRate = 1f; 
    [SerializeField] private float _cooldownDuration = 2f;  

    [SerializeField] private float _currentEnergy;
    private bool _isExhausted = false; 
    private float _cooldownTimer = 0f;

    private float _verticalInput, _horizontalInput;
    private Vector3 _movementDirection;
    private Rigidbody _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _currentSpeed = _movementSpeed;
        _currentEnergy = _maxEnergyDuration; 
    }

    private void Update()
    {
        SetInputs();
        HandleEnergy();
    }

    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInputs()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(_jumpKey) && _canJump && IsGrounded())
        {
            _canJump = false;
            SetPlayerJumping();
            Invoke(nameof(ResetJumping), _jumpCooldown);
        }
    }

    private void HandleEnergy()
    {
       
        if (_isExhausted)
        {
            _currentSpeed = _movementSpeed;
            _cooldownTimer -= Time.deltaTime;

            RechargeEnergy();

            
            if (_cooldownTimer <= 0f)
            {
                _isExhausted = false;
            }
            return;
        }

        //karakter dururken shifte bastığında stamina harcanmasın diye kontrol
        bool isMoving = _verticalInput != 0 || _horizontalInput != 0;

        //hiç bir sorun yoksa stamina varsa karkater yüyüyorsa ve shifte basıyorsa
        if (Input.GetKey(_runKey) && _currentEnergy > 0f && isMoving)
        {
            _currentSpeed = _movementSpeed * _runMultiplier;
            _currentEnergy -= Time.deltaTime; 

           
            if (_currentEnergy <= 0f)
            {
                _currentEnergy = 0f;
                _isExhausted = true;
                _cooldownTimer = _cooldownDuration; 
            }
        }
        else
        {
            _currentSpeed = _movementSpeed;
            RechargeEnergy();
        }
    }

    private void RechargeEnergy()
    {
        if (_currentEnergy < _maxEnergyDuration)
        {
            _currentEnergy += _energyRechargeRate * Time.deltaTime;
            if (_currentEnergy > _maxEnergyDuration)
            {
                _currentEnergy = _maxEnergyDuration;
            }
        }
    }

    private void SetPlayerMovement()
    {
        _movementDirection = _oriantationTransform.forward * _verticalInput + _oriantationTransform.right * _horizontalInput;
        _playerRigidbody.AddForce(_movementDirection.normalized * _currentSpeed, ForceMode.Force);
    }

    private void SetPlayerJumping()
    {
        Vector3 currentVel = _playerRigidbody.linearVelocity;
        _playerRigidbody.linearVelocity = new Vector3(currentVel.x, 0f, currentVel.z);
        _playerRigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void ResetJumping()
    {
        _canJump = true;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, groundLayer);
    }

    private void OnDrawGizmosSelected()        //for debug 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * rayDistance);
    }
}