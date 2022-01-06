using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class DartsBehaviour : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    [SerializeField]
    private CinemachineVirtualCamera _camera;
    private float _defaultFOV;
    private float _currentFOV;
    private float _defaultNoiseAmp;
    private float _currentNoiseAmp;
    private float _defaultNoiseFreq;
    private float _currentNoiseFreq;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    [SerializeField] 
    private GameObject dartsPoolParent;
    private List<Rigidbody> _dartsPool;
    private List<float> _dartsPoolSpawnTime;
    [SerializeField] 
    private int poolSize;
    [SerializeField]
    private Rigidbody dartPrefab;
    private Vector3 dartsBoardCenterPos;
    private RaycastHit[] _hitResults;
    [FormerlySerializedAs("_coolDownTime")] public float coolDownTime = 1f;
    private float _timer;
    private float _precisionTimer;
    private bool _canShoot;
    private bool _isHolding;
    private float shotVelMultiplier;
    [SerializeField] 
    private GameEvent _exitDarts;

    private void Awake()
    {
        _timer = 0;
        _precisionTimer = 0;
        _canShoot = false;
        _isHolding = false;
        _hitResults = new RaycastHit[1];
        InitPool();
        _timer = coolDownTime + 1f;
        enabled = false;
        _cameraNoise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        dartsBoardCenterPos = transform.position;
    }

    void OnEnable()
    {
        PlayerProperties.FreezeMovement = true;
        if (_defaultFOV == 0 || _defaultNoiseAmp == 0 || _defaultNoiseFreq == 0)
        {
            _defaultFOV = _camera.m_Lens.FieldOfView;
            _defaultNoiseAmp = _cameraNoise.m_AmplitudeGain;
            _defaultNoiseFreq = _cameraNoise.m_FrequencyGain;
        }
        _currentFOV = _defaultFOV;
        _currentNoiseAmp = _defaultNoiseAmp;
        _currentNoiseFreq = _defaultNoiseFreq;
        _canShoot = false;
        _isHolding = false;
        _timer = coolDownTime + 1f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0f, coolDownTime + 1f);

        if (InputManager.Instance.PlayerInput.Shoot.hasStarted && _timer >= coolDownTime)
        {
            _isHolding = true;
            _precisionTimer += Time.deltaTime;
            _precisionTimer = Mathf.Clamp(_precisionTimer, 0f, 5f);
            _currentFOV = Mathf.Lerp(_currentFOV, 10, Time.deltaTime * 1);
            //_currentNoiseAmp = Mathf.Lerp(_currentNoiseAmp, 2f, Time.deltaTime);
            _currentNoiseFreq = Mathf.Lerp(_currentNoiseFreq, 2f, Time.deltaTime);
            //_cameraNoise.m_AmplitudeGain = _currentNoiseAmp;
            _cameraNoise.m_FrequencyGain = _currentNoiseFreq;
            _camera.m_Lens.FieldOfView = _currentFOV;
        }
        
        if ((InputManager.Instance.PlayerInput.Shoot.isDone && _isHolding) || _precisionTimer >= 3.5f)
        {
            _timer = 0;
            _precisionTimer = 0;
            _isHolding = false;
            shotVelMultiplier = MapValue(0, 3, 0.3f, 1, InputManager.Instance.PlayerInput.Shoot.holdTime);
            _canShoot = true;
            StartCoroutine(ResetFOVOvertime(0.6f));
            //_currentNoiseAmp = _defaultNoiseAmp;
            _currentNoiseFreq = _defaultNoiseFreq;
            //_cameraNoise.m_AmplitudeGain = _currentNoiseAmp;
            _cameraNoise.m_FrequencyGain = _currentNoiseFreq;
            _camera.m_Lens.FieldOfView = _currentFOV;
            return;
        }

        if (InputManager.Instance.PlayerInput.ExitInteraction)
        {
           _exitDarts.Raise();
        }
    }

    private void FixedUpdate()
    {
        if (_canShoot)
        {
            _canShoot = false;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            int hit = Physics.RaycastNonAlloc(ray, _hitResults);

            Rigidbody dart = GetFromPool();
            dart.gameObject.SetActive(true);

            ResetPosition(dart.transform);
            dart.velocity = Vector3.zero;
            dart.angularDrag = 0;
            dart.angularVelocity = Vector3.zero;
            dart.AddForce(Camera.main.transform.forward * 55 * shotVelMultiplier, ForceMode.Impulse);
        }
    }

    private void OnDisable()
    {
        PlayerProperties.FreezeMovement = false;
    }

    void InitPool()
    {
        _dartsPool = new List<Rigidbody>(poolSize);
        _dartsPoolSpawnTime = new List<float>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            Rigidbody dart = Instantiate(dartPrefab, Vector3.zero, Quaternion.identity, dartsPoolParent.transform);
            _dartsPool.Add(dart);
            dart.gameObject.SetActive(false);
            _dartsPoolSpawnTime.Add(Time.time);
        }
    }

    Rigidbody GetFromPool()
    {
        //Get unused element
        
        for (int i = 0; i < _dartsPool.Count; i++)
        {
            if (!_dartsPool[i].gameObject.activeSelf)
            {
                _dartsPoolSpawnTime[i] = Time.time;
                return _dartsPool[i];
            }
        }

        //If cant get unused elements it gets the older element
        
        float olderTime = 0;
        int olderIndex = 0;

        for(int i = 0; i < _dartsPoolSpawnTime.Count; i++)
        {
            if (_dartsPoolSpawnTime[i] - Time.time > olderTime)
            {
                olderTime = _dartsPoolSpawnTime[i];
                olderIndex = i;
            }
        }

        _dartsPoolSpawnTime[olderIndex] = Time.time;
        return _dartsPool[olderIndex];
        
    }

    void ResetPosition(Transform dart)
    {
        dart.position = Camera.main.transform.position;
        dart.rotation = Quaternion.identity;
        dart.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y + 180, UnityEngine.Random.Range(0f,180f));
    }


    public void Score(Vector3 contactPoint)
    {
        int score = 0;
        
        Vector2 contactPointDir = new Vector2(contactPoint.y, contactPoint.z) -
                                  new Vector2(transform.position.y, transform.position.z);
        contactPointDir.Normalize();
        Vector2 rightDir = new Vector2(dartsBoardCenterPos.y + 1, dartsBoardCenterPos.z) -
                           new Vector2(dartsBoardCenterPos.y, dartsBoardCenterPos.z);
        rightDir.Normalize();
        float angle = Vector2.Angle(rightDir, contactPointDir);

        float distance = Vector2.Distance(new Vector2(contactPoint.y, contactPoint.z), dartsBoardCenterPos);
        
        switch (angle, distance)
        {
            case var _ when angle >= 351:

                score = 6;
                Debug.Log(score);
                break;
        }
    }
    
    
    public float MapValue(float oldMin, float oldMax, float newMin, float newMax, float currentValue){
 
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((currentValue - oldMin) * newRange) / oldRange) + newMin;
 
        return(newValue);
    }

    IEnumerator ResetFOVOvertime(float time)
    {
        float timer = 0;
        float vel = Mathf.Abs(_defaultFOV - _currentFOV) / time;
        while (_currentFOV != _defaultFOV)
        {
            timer += Time.deltaTime;
            _currentFOV += Time.deltaTime * vel;
            _currentFOV = Mathf.Clamp(_currentFOV, 0, _defaultFOV);
            _camera.m_Lens.FieldOfView = _currentFOV;
            yield return null;
        }
        Debug.Log(timer);
        yield return null;
    }
}
