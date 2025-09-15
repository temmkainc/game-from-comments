using Comments.UI;

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
        }

        public void SetHealthBar(float value)
        {
            HealthBar.SetValue(value);
        }
    }
}
