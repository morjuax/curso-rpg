using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(menuName = "Stats")]
public class PersonajeStats : ScriptableObject
{
    public float Damage = 5f;
    public float Defensa = 2f;
    public float Velocidad = 5f;
    public float Nivel;
    public float ExpActual;
    public float ExpRequeridaSiguienteNivel;
    [Range(0f, 100f)] public float PorcentajeCritico;
    [Range(0f, 100f)] public float PorcentajeBloqueo;

    public void ResetValues()
    {
        Damage = 5f;
        Defensa = 2f;
        Velocidad = 5f;
        Nivel = 1f;
        ExpActual = 0f;
        ExpRequeridaSiguienteNivel = 0f;
        PorcentajeBloqueo = 0f;
        PorcentajeCritico = 0f;
    }
}
