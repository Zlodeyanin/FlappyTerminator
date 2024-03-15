using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    public virtual void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}