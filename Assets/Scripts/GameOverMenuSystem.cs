using Assets.Scripts;

public class GameOverMenuSystem : MenuSystem
{
    public void DisplayGameOverMenu()
    {
        SetSelectedGameObject();
        gameObject.SetActive(true);
    }
}
