using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public GameScene currentScene;
    public TextBoxController textBox;
    public SpriteSwitcher backgroundController;
    public ChooseController chooseController;
    private State state = State.IDLE;


    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            textBox.PlayScene(storyScene);
            backgroundController.SetImage(storyScene.background);
        }
    }

    void Update()
    {
       
    }

    public void nextText(){
        if (state == State.IDLE && textBox.IsCompleted())
        {
            if (textBox.IsLastSentence())
            {
                PlayScene((currentScene as StoryScene).nextScene);
                enterLevel();
            }
            else
            {
                textBox.PlayNextSentence();
            }
        }
    }

    public void enterLevel(){
        if((currentScene as StoryScene).nextScene == null){
            SceneManager.LoadScene(4);
        }
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        textBox.Hide();
        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SwitchImage(storyScene.background);
            yield return new WaitForSeconds(1f);
            textBox.ClearText();
            textBox.Show();
            yield return new WaitForSeconds(1f);
            textBox.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }
}