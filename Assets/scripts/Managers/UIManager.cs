using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    
    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;

    private float _vidaActual;
    private float _vidaMax;
    private float _manaActual;
    private float _manaMax;

    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
    }

    private void ActualizarUIPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, _vidaActual / _vidaMax, 10f * Time.deltaTime);
        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, _manaActual / _manaMax, 10f * Time.deltaTime);

        vidaTMP.text = $"{_vidaActual}/{_vidaMax}";
        manaTMP.text = $"{_manaActual}/{_manaMax}";
    }
    

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        _vidaActual = pVidaActual;
        _vidaMax = pVidaMax;
    }
    
    public void ActualizarManaPersonaje(float pManaActual, float pManaMax)
    {
        _manaActual = pManaActual;
        _manaMax = pManaMax;
    }
}
