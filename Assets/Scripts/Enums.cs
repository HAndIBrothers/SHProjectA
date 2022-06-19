public static class Enums
{
    public enum eScene
    {
        APP = 0,
        LOGO = 1,
        LOBBY = 2,
        SELECT = 3,
        IN_GAME = 4,
        RESULT = 5,
        MINI_GAME_01 = 6,
        MINI_GAME_02 = 7,
        MINI_GAME_03 = 8
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
