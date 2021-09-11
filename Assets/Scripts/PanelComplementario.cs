using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Pregunta
{
    public string informacionComplementaria;
}//fin de la clase Pregunta
public class PanelComplementario : MonoBehaviour
{
    //se inicialisa los objetos
    public GameObject panelInformacionComplementaria;
    public Text informacionComplementaria;
    public Game game;

    private int nivelPregunta;
    private int preguntaAlAzar;

    // Update is called once per frame
    void Update()
    {
        
    }//fin del metodo Update

    //En el metodo Continuar se escondera el panel complementaria y mostrara la siguiente pregunta en el juego
    public void Continuar()
    {
        panelInformacionComplementaria.SetActive(false);
        game.SelecionarPregunta();
    }//fin del metodo Continuar

    //En el metodo Desplegar se cargaran las preguntas con su respectiva informacion complementaria
    public void Desplegar()
    {
        nivelPregunta = game.nivelPregunta;
        nivelPregunta--;
        preguntaAlAzar = game.preguntaAlAzar;
        panelInformacionComplementaria.SetActive(true);
        //Cargar la informacion del banco de preguntas con la informacion complementaria

        informacionComplementaria.text = game.bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].informacionComplementaria;

    }//fin del metedo Desplegar
}//fin de la clase PanelComplementario
