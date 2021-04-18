namespace CodeBase.Infrastructure.ScenesLogic
{
    public static class ScenesPaths
    {
        public const string Initial = "Initial";

        private const string _levelPath = "Level";

        public static string LevelPath(int levelNumber) => _levelPath + levelNumber;
    }
}