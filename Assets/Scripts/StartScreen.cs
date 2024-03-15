using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

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
        PlayButtonClicked?.Invoke();
    }
}