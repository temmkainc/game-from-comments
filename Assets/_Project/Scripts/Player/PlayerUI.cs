using UnityEngine.UI;

namespace Comments.Level
{
    public class PlayerUI
    {
        public Image HealthBar { get; }
        private readonly PlayerInputContainer _inputContainer;

        public PlayerUI(PlayerInputContainer inputContainer)
        {
            _inputContainer = inputContainer;

            HealthBar = _inputContainer.HealthBar;
        }

        public void SetHealthBar(float value)
        {
            HealthBar.fillAmount = value;
        }
    }
}
