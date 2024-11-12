using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class GamePauseUISystem : MenuSystem
    {
        private PlayerInput _playerInput;

        public void DisplayGamePauseMenu(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            InputActionMap pauseMenuActionMap = playerInput.actions.actionMaps.Single(am => am.name == "PauseMenu");
            playerInput.currentActionMap = pauseMenuActionMap;
            Time.timeScale = 0f;
            SetSelectedGameObject();
            gameObject.SetActive(true);
        }

        public void UndisplayGamePauseMenu(PlayerInput playerInput)
        {
            ResumeGame(playerInput);
        }

        public void UndisplayGamePauseMenu()
        {
            ResumeGame(_playerInput);
        }

        private void ResumeGame(PlayerInput playerInput)
        {
            InputActionMap battleActionMap = playerInput.actions.actionMaps.Single(am => am.name == "Battle");
            playerInput.currentActionMap = battleActionMap;
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            _playerInput = null;
        }
    }
}
