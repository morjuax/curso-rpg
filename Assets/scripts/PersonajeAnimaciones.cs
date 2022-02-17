using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerWalk;
    
    private Animator _animator;
    private PersonajeMovimiento _characterMovement;

    private readonly int _directionX = Animator.StringToHash("x");
    private readonly int _directionY = Animator.StringToHash("y");
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterMovement = GetComponent<PersonajeMovimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLayers();
        
        if (_characterMovement.InMovement == false)
        {
            return;
        }
        
        _animator.SetFloat(_directionX, _characterMovement.DireccionMovimiento.x);
        _animator.SetFloat(_directionY, _characterMovement.DireccionMovimiento.y);
    }

    private void ActiveLayer(string nameLayer)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(nameLayer), 1);
    }

    private void UpdateLayers()
    {
        if (_characterMovement.InMovement)
        {
            ActiveLayer(layerWalk);
        }
        else
        {
            ActiveLayer(layerIdle);
        }
    }
}
