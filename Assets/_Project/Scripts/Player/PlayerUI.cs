using Comments.UI;
using UnityEngine.Events;

namespace Comments.Level
{
    public class PlayerUI
    {
        public SmoothBar HealthBar { get; }
        private readonly PlayerInputContainer _inputContainer;

        public PlayerUI(PlayerInputContainer inputContainer)
        {
            _inputContainer = inputContainer;
            HealthBar = _inputContainer.HealthBar;
            SetShootingJoystickActive(false);
            SetActionButtonActive(false);
        }

        public void ChangeActionButtonListener(UnityAction action)
        {
            _inputContainer.ActionButton.onClick.RemoveAllListeners();
            _inputContainer.ActionButton.onClick.AddListener(action);
        }

        public void DisableAdditionalUI()
        {
            SetActionButtonActive(false);
            SetShootingJoystickActive(false);
        }

        public void SetHealthBar(float value)
        {
            HealthBar.SetValue(value);
        }

        public void SetActionButtonActive(bool value)
        {
            _inputContainer.ActionButton.gameObject.SetActive(value);
        }

        public void SetShootingJoystickActive(bool value)
        {
            _inputContainer.ShootingJoystick.gameObject.SetActive(value);
        }
    }
}
