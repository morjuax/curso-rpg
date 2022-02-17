using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour
{
    [SerializeField] private int nivelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    public int Nivel { get; set; }

    private float expActualTmp;
    private float expRequeridaSiguienteNivel;
    
    // Start is called before the first frame update
    void Start()
    {
        Nivel = 1;
        expRequeridaSiguienteNivel = expBase;
        ActualizarBarraExp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExp(2f);
        }
    }

    public void AddExp(float expObtenida)
    {
        if (expObtenida > 0f)
        {
            float expRestanteNuevoNivel = expRequeridaSiguienteNivel - expActualTmp;
            if (expObtenida >= expRestanteNuevoNivel)
            {
                expObtenida -= expRestanteNuevoNivel;
                ActualizarNivel();
                AddExp(expObtenida);
            }
            else
            {
                expActualTmp += expObtenida;
                if (expActualTmp == expRequeridaSiguienteNivel)
                {
                    ActualizarNivel();
                }
            }
        }

        ActualizarBarraExp();
    }

    private void ActualizarNivel()
    {
        if (Nivel < nivelMax)
        {
            Nivel++;
            expActualTmp = 0f;
            expRequeridaSiguienteNivel *= valorIncremental;
        }
    }

    private void ActualizarBarraExp()
    {
        UIManager.Instance.ActualizarExpPersonaje(expActualTmp, expRequeridaSiguienteNivel);
    }
}
