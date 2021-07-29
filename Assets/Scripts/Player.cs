using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _gravity = 1f;
    [SerializeField]
    private float _jumpHeight = 25.0f;

    private float _yVelocity;
    private bool _canDoubleJump = false;
    private bool _canJumping = true;
    private bool _canPlaySound = false;
    private bool _canPlayJumpSound = true;
    private bool _onJumpButton = false;
    
    

    private int _coin;
    [SerializeField]
    private int _lives = 5;
    [SerializeField]
    private GameObject _coinPrefab;
    private UIManager _uiManager;
    private DisapearPlatform _platform; 
    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private AudioSource _walkSound, _walkSound2, _jump, _landOnTheGround, _landOnTheEnemy,_death;

    [SerializeField]
    private GameObject _camera;
    

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _platform = GameObject.Find("Environment").GetComponent<DisapearPlatform>();       

        if (_anim == null)
        {
            Debug.Log("Animator is NULL");
        }
        

        if (_uiManager == null)
        {
            Debug.Log("UIManager is NULL");
        }

        if (_platform == null)
        {
            Debug.Log("Platform is NULL");
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();       
    }

    public void VictoryAnim()
    {
        _anim.SetTrigger("OnVictory");        
        _anim.SetBool("isJumping", false);
        _canJumping = false;
    }

    public void JumpingButton()
    {
        _yVelocity += _jumpHeight*4;
        _onJumpButton = true;
    }

    public void CoinUpdate()
    {
        _coin = _coin + 1;
        _uiManager.UpdateCoinDisplay(_coin);
    }

    public void Damage()
    {
        _lives--;
        _anim.SetTrigger("OnDeath");        
        _uiManager.UpdateLivesDisplay(_lives);
        _anim.SetTrigger("OnRespawn");
        
        if (_lives < 1)
        {
            _uiManager.GameOver();
            _camera.transform.parent = null;

            if (_death.isPlaying == false)
            {
                _death.Play();
            }
            Destroy(this.gameObject, 3f);
        }            
    }    

    void PlayerMovement()
    {        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
       
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _anim.SetBool("isIdle", false);
            _anim.SetBool("isRunning", true);
            if (_controller.isGrounded == true)
            {
                StartCoroutine(WalkRoutine());
            }
            
        }
        else
        {
            _anim.SetBool("isRunning", false);
            _anim.SetBool("isIdle", true);
        }


        if (_controller.isGrounded == true)
        {
            _onJumpButton = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canPlayJumpSound = true;
                _canDoubleJump = true;                                    
            }
                        
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true && _onJumpButton == false)
            {
                _yVelocity += _jumpHeight;
                _canPlayJumpSound = true;
                _canDoubleJump = false;
                
            }
            else
            {
                _yVelocity -= _gravity;
                _canPlayJumpSound = false;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && _canJumping == true )
        {
            _anim.SetBool("isIdle", false);
            _anim.SetBool("isJumping", true);
            _canPlaySound = true;
            if (_jump.isPlaying == false && _canPlayJumpSound == true)
            {
                _jump.Play();
            }
        }
        else
        {
            if (_controller.isGrounded == true && _canJumping == true )
            {
                _anim.SetBool("isJumping", false);
                _anim.SetTrigger("Landed");
                _anim.SetBool("isIdle", true);
                if (_landOnTheGround.isPlaying == false && _landOnTheEnemy.isPlaying == false && _canPlaySound == true)
                {
                    _landOnTheGround.Play();
                }
                _canPlaySound = false;
            }
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void PlatformCollision()
    {
        _canDoubleJump = false;
       _yVelocity -= _gravity*3;                
    }

    public void LandedOnTheEnemySound()
    {
        if (_landOnTheEnemy.isPlaying == false && _canPlaySound == true)
        {
            _landOnTheEnemy.Play();
        }
        _canPlaySound = false;
    }

    IEnumerator WalkRoutine()
    {
        if (_walkSound.isPlaying == false)
        {
            _walkSound.Play();
        }
        yield return new WaitForSeconds(_walkSound.clip.length);
        if (_walkSound2.isPlaying == false)
        {
            _walkSound2.Play();
        }
        yield return new WaitForSeconds(_walkSound2.clip.length);
    }   
}
