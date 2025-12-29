namespace Hezeru;

public static class ResourcePaths
{
    public static class Animations
    {
        public static class Json
        {
            public const string PLAYER = "Content/Animations/Player.json";
        }

        public const string LOADING_WHEEL = "Animations/LoadingWheel";
        public const string PLAYER = "Animations/Player";
    }

    public static class Atlases
    {
        public static class MainMenu
        {
            public const string PLAY_BUTTON = "Atlases/UI/MainMenuPlayButton";
        }

        public static class World
        {
            public const string TERRAIN_TILES = "Atlases/WorldTerrain";
            public const string COLLISIONLESS_TILES = "Atlases/WorldCollisionlessTiles";
        }
    }

    public static class Fonts
    {
        public const string CONSOLAS = "Fonts/Consolas";
        public const string CONSOLAS_18 = "Fonts/Consolas-18";
    }

    public static class Maps { }

    public static class Textures
    {
        public static class MainMenu
        {
            public const string LOGO = "Sprites/HezeruLogo";
            public const string BACKGROUND = "Sprites/UI/MainMenuBackground";
        }

        public static class UI
        {
            public const string MOUSE_POINTER = "Sprites/MousePointer";
        }
    }
}
