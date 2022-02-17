using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("Config")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private TextMeshProUGUI vidaTMP;

    private float _vidaActual;
    private float _vidaMax;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
    }

    private void ActualizarUIPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, _vidaActual / _vidaMax, 10f * Time.deltaTime);

        vidaTMP.text = $"{_vidaActual}/{_vidaMax}";
    }

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        _vidaActual = pVidaActual;
        _vidaMax = pVidaMax;
    }
}
