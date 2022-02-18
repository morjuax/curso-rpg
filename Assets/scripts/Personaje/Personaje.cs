﻿using System;
using UnityEngine;

public class Personaje: MonoBehaviour
{
    [SerializeField] private PersonajeStats stats;
    
    public PersonajeVida PersonajeVida { get; private set; }
    public PersonajeAnimaciones PersonajeAnimaciones { get; private set; }

    public PersonajeMana PersonajeMana { get; private set; }

    private void Awake()
    {
        PersonajeVida = GetComponent<PersonajeVida>();
        PersonajeAnimaciones = GetComponent<PersonajeAnimaciones>();
        PersonajeMana = GetComponent<PersonajeMana>();
    }

    public void RestaurarPersonaje()
    {
        PersonajeVida.RestaurarPersonaje();
        PersonajeAnimaciones.RevivirPersonaje();
        PersonajeMana.RestablerMana();
    }

    private void AtributoRespuesta(TipoAtributo tipo)
    {
        if (stats.PuntosDisponibles <= 0)
        {
            return;
        }
        
        switch (tipo)
        {
            case TipoAtributo.Fuerza:
                stats.Fuerza++;
                stats.AddBonusPorAtributoFuerza();
                break;
            case TipoAtributo.Inteligencia:
                stats.Inteligencia++;
                stats.AddBonusPorAtributoInteligencia();
                break;
            case TipoAtributo.Destreza:
                stats.Destreza++;
                stats.AddBonusPorAtributoDestreza();
                break;
        }

        stats.PuntosDisponibles -= 1;
    }

    private void OnEnable()
    {
        AtributoButton.EventoAgregarAtributo += AtributoRespuesta;
    }

    private void OnDisable()
    {
        AtributoButton.EventoAgregarAtributo -= AtributoRespuesta;
    }
}