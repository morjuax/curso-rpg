using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Stats")] 
    [SerializeField] private PersonajeStats stats;
    
    [Header("Paneles")] 
    [SerializeField] private GameObject panelStats;
    
    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    [SerializeField] private Image expPlayer;
    
    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI nivelTMP;

    [Header("Stats")] 
    [SerializeField] private TextMeshProUGUI statDamageTMP;
    [SerializeField] private TextMeshProUGUI statDefesaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpRequeridaTMP;
    

    private float _vidaActual;
    private float _vidaMax;
    private float _manaActual;
    private float _manaMax;
    private float _expActual;
    private float _expRequeridaNuevoNivel;

    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
        ActualizarPanelStats();
    }

    private void ActualizarUIPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, _vidaActual / _vidaMax, 10f * Time.deltaTime);
        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, _manaActual / _manaMax, 10f * Time.deltaTime);
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, _expActual / _expRequeridaNuevoNivel, 10f * Time.deltaTime);

        vidaTMP.text = $"{_vidaActual}/{_vidaMax}";
        manaTMP.text = $"{_manaActual}/{_manaMax}";
        expTMP.text = $"{((_expActual/_expRequeridaNuevoNivel) * 100):F2}%";
        nivelTMP.text = $"Nivel {stats.Nivel}";
    }

    private void ActualizarPanelStats()
    {
        if (panelStats.activeSelf == false)
        {
            return;
        }

        statDamageTMP.text = stats.Damage.ToString();
        statDefesaTMP.text = stats.Defensa.ToString();
        statCriticoTMP.text = $"{stats.PorcentajeCritico} %";
        statBloqueoTMP.text = $"{stats.PorcentajeBloqueo} %";
        statVelocidadTMP.text = stats.Velocidad.ToString();
        statNivelTMP.text = stats.Nivel.ToString();
        statExpTMP.text = stats.ExpActual.ToString();
        statExpRequeridaTMP.text = stats.ExpRequeridaSiguienteNivel.ToString();
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
    
    public void ActualizarExpPersonaje(float pExpActual, float pExpRequerida)
    {
        _expActual = pExpActual;
        _expRequeridaNuevoNivel = pExpRequerida;
    }
    
}
