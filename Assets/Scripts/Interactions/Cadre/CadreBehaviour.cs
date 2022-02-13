using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CadreBehaviour : MonoBehaviour
{
    [SerializeField]private bool isSeeing;
    [SerializeField] private GameEvent exitCadre;
    void Awake()
    {
        this.enabled = false;
    }
    private void OnEnable()
    {
        //Player is now viewing the portrait/cadre player is frozen
        isSeeing = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isSeeing)
            return;
        PlayerSeeingtheCadre();
    }
    private void PlayerSeeingtheCadre()
    {
        if (InputManager.Instance.PlayerInput.ExitInteraction)
        {
            //Stop viewing the cadre
            isSeeing = false;
            exitCadre.Raise(); //Player can resume moving and interact again
        }
    }
}
