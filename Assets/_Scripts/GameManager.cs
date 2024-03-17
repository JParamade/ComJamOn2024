using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StateMachine _stateMachine;
    public PutadaBase nORMAL;
    public PutadaBase[] _putadas;
    public float locura;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _stateMachine = GetComponent<StateMachine>();
    }


    public IEnumerator CallPutada(float NivelLocura, float temp)
    {
        locura = NivelLocura;
        int num = Random.Range(0, _putadas.Length);
        _stateMachine.ChangeState(_putadas[num]);
        yield return new WaitForSeconds(temp);
        _stateMachine.ChangeState(nORMAL);

    }

    public void GoToNextScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
