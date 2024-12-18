using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunBehiavor : MonoBehaviour
{
    public float followSpeed = 5f;         // Velocidad con la que sigue al jugador
    public float stopDistance = 1f;        // Distancia en la que el enemigo deja de seguir al jugador
    public float diversionAngle = 30f;     // �ngulo de desviaci�n al llegar cerca del jugador
    public float destroyDelay = 1f;        // Tiempo antes de destruirse tras desviarse
    public Transform player;              // Referencia al jugador
    public bool isFollowing = false;       // Estado de seguimiento
    public bool hasStoppedFollowing = false; // Para que el desv�o solo ocurra una vez
    public Animator enemyAnimator;
    public Vector3 diversionDirection;     // Direcci�n de desv�o calculada
    public bool isCurving = false;
    public AudioSource sombraAudio;
    public  AudioSource footstepSound;
    public float initialY;

    private void Awake()
    {
        GameObject sombraObject = GameObject.Find("SombraAudio");

        if (sombraObject != null)
        {
            sombraAudio = sombraObject.GetComponent<AudioSource>();
        }


    }

    private void Start()
    {
        // Encuentra al jugador usando la etiqueta "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialY = transform.position.y;
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        enemyAnimator = GetComponentInChildren<Animator>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.gameObject.name == "SonidoPisadasCorriendo")
            {
                footstepSound = audioSource;
                break;
            }

        }
    }
        private void Update()
        {
        if (isFollowing && !hasStoppedFollowing)
        {
            enemyAnimator.SetTrigger("Running");
            
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play(); // Activa el sonido si est� siguiendo y el sonido no se est� reproduciendo
            }
            if (!sombraAudio.isPlaying)
            {
                sombraAudio.Play(); // Activa el sonido de la sombra solo si no está reproduciéndose
            }

            FollowPlayer();
        }
        else if (isCurving)
        {
            MoveInDiversionDirection();
        }
        else
        {
            if (footstepSound.isPlaying)
            {
                footstepSound.Stop(); // Detiene el sonido de pisadas si no está siguiendo o está en desvío
            }

            if (sombraAudio.isPlaying)
            {
                sombraAudio.Stop(); // Detiene el sonido de la sombra si no está siguiendo
            }
        }

        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
        }


    private void FollowPlayer()
    {
        

        // Calcula la distancia al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el enemigo est� a la distancia especificada, calcula la direcci�n de desv�o y comienza la curva
        if (distanceToPlayer <= stopDistance)
        {
            hasStoppedFollowing = true;
            StartCoroutine(DivertAndDestroy());
        }
        else
        {
            // Sigue al jugador
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }

    private IEnumerator DivertAndDestroy()
    {
        // Determina aleatoriamente si el enemigo se desv�a hacia la izquierda o la derecha
        float angle = Random.Range(0, 2) == 0 ? -diversionAngle : diversionAngle;

        // Calcula la direcci�n de desv�o girando el vector hacia el �ngulo determinado
        diversionDirection = Quaternion.Euler(0, angle, 0) * (player.position - transform.position).normalized;

        isCurving = true;  // Activa el estado de curva
        yield return new WaitForSeconds(destroyDelay);  // Espera antes de destruir

        Destroy(gameObject);
        //sombraAudio.Play();
    }

    private void MoveInDiversionDirection()
    {
        // Mueve el enemigo en la direcci�n de desv�o de manera suave, simulando una curva
        transform.position += diversionDirection * followSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        sombraAudio.Stop();
        Destroy(gameObject);
        
    }
}