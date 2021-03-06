public static class Enums
{
    public enum eDirection
    {
        UP = 0,
        DOWN = 1
    }
    public enum eScene
    {
        APP = 0,
        LOGO = 1,
        LOBBY = 2,
        SELECT = 3,
        MINI_GAME_01 = 4,
        MINI_GAME_02 = 5,
        MINI_GAME_03 = 6,
        MINI_GAME_04 = 7
    }

    public static class MiniGame03
    {
        public static class Card
        {
            public enum eStatus
            {
                NONE = -1,
                OPEN = 0,
                CLOSE = 1,
                SELECT = 2
            }
        }
    }
}
