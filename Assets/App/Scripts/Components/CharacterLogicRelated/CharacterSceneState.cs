public enum CharacterAnimState
{
    Idle,
    Drink
}

public static class CharacterSceneState
{
    public static CharacterAnimState CurrentState = CharacterAnimState.Idle;
}
