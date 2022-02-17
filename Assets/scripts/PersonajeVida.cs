using System;
using UnityEngine;

public class PersonajeVida: VidaBase
{
    public bool puedeSerCurado => Salud < saludMax;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {
        if (puedeSerCurado)
        {
            Salud += cantidad;
            if (Salud > saludMax)
            {
                Salud = saludMax;
            }
            ActualizarBarraVida(Salud, saludMax);
        }
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        
    }
}