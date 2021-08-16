using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] float horizontalSpeed;

    private bool play = false;
    void Awake() 
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
         GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state){
        if(state == GameState.PlayerPlay){
            play = true;
        }
        else{
            play = false;
        }
    } 


    void Update()
    {
        if(play){
        float horizontalAxisValue = Mathf.Clamp(Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime, -2f, +2f);
        float newZValue = forwardSpeed * Time.deltaTime;
        float newYValue = 0f;

        transform.position = new Vector3(
                                        Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime, -2f, +2f),
                                        transform.position.y + newYValue,
                                        transform.position.z + newZValue
                                        );
        }
    }

}
