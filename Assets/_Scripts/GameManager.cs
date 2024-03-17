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

    public List<GameObject> heads;
    public Animator clientAnimator;

    public int state = 0;

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

    private void Update()
    {
        if (state == 1) { NextClient(); }
        else if (state == 2) { StayClient(); }
        else if (state == 3) { ClientEnd(); }

        if (Input.GetKeyDown(KeyCode.P)) { state++; }
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

    public void RandomHead() {
        int randomHead = Random.Range(0, heads.Count);

        foreach (GameObject head in heads)
        {
            if (heads[randomHead] == head) { head.SetActive(true); }
            else { head.SetActive(false); }
        }
    }

    public void NextClient() { clientAnimator.SetInteger("state", state);  }
    public void StayClient() { clientAnimator.SetInteger("state", state); }
    public void ClientEnd() { clientAnimator.SetInteger("state", state); }
}
