using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class DartsBehaviour : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    [SerializeField]
    private CinemachineVirtualCamera _camera;
    [SerializeField] 
    private GameObject dartsPoolParent;
    private List<Rigidbody> _dartsPool;
    private List<float> _dartsPoolSpawnTime;
    [SerializeField] 
    private int poolSize;
    [SerializeField]
    private Rigidbody dartPrefab;
    [SerializeField] 
    private Collider dartBoardCollider;
    private RaycastHit[] _hitResults;
    private float _coolDownTime = 1f;
    private float _timer;
    private bool _canShoot;
    [SerializeField] 
    private GameEvent _exitDarts;

    private void Awake()
    {
        _timer = 0;
        _canShoot = false;
        _hitResults = new RaycastHit[1];
        InitPool();
        _timer = _coolDownTime + 1f;
        enabled = false;
    }

    void OnEnable()
    {
        PlayerProperties.FreezeMovement = true;
        _canShoot = false;
        _timer = _coolDownTime + 1f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0f, _coolDownTime + 1f);
        if (InputManager.Instance.PlayerInput.Shoot)
        {
            if (_timer > _coolDownTime)
            {
                _timer = 0;
                _canShoot = true;
                return;
            }
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
            dart.AddForce(Camera.main.transform.forward * 50, ForceMode.Impulse);
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
        dart.rotation = Quaternion.Euler(0, 0, 90);
    }
}
