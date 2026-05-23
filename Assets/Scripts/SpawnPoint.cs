using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    private Mario mario;

    // Use this for initialization
    void Start () {
        mario = FindObjectOfType<Mario> ();
    }
    
    // Update is called once per frame
    void Update () {
        // --- ESCUDO 1: Si Mario murió o no ha cargado, detenemos el código aquí mismo ---
        if (mario == null) {
            // Intentamos buscarlo de nuevo en caso de que acabe de revivir
            mario = FindObjectOfType<Mario>(); 
            if (mario == null) return; // Si sigue sin existir, saltamos el fotograma
        }

        // update spawn pos if Player passes checkpoint
        if (mario.gameObject.transform.position.x >= transform.position.x) {
            
            GameStateManager t_GameStateManager = FindObjectOfType<GameStateManager> ();
            
            // --- ESCUDO 2: Modo prueba (Si no hay gestor, no intentes guardar datos) ---
            if (t_GameStateManager != null) {
                t_GameStateManager.spawnPointIdx = Mathf.Max (t_GameStateManager.spawnPointIdx, gameObject.transform.GetSiblingIndex ());
            }
            
            // Apagamos este punto de control para que no siga consumiendo memoria
            gameObject.SetActive (false);
        }
    }
}