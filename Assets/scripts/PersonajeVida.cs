using System;
using UnityEngine;

public class PersonajeVida: VidaBase
{
    public static Action EventoPersonajeDerratado;
    public bool Derrotado { get; private set; }
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
        if (Derrotado)
        {
            return;
        }

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

    protected override void PersonajeDerratado()
    {
        Derrotado = true;
        EventoPersonajeDerratado?.Invoke();
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        
    }
}