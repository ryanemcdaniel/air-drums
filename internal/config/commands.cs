namespace Global {
    public static class CMD {

        public static int MIDI_WAIT = 10; // Centiseconds

        // Left hand MIDI command byte codes
        public static byte[]    LEFT_TAP_QUAD_1    = new byte[]{ 0b10011110, 92, 0b01111111 };
        public static byte[]    LEFT_TAP_QUAD_2    = new byte[]{ 0b10011110, 93, 0b01111111 };
        public static byte[]    LEFT_TAP_QUAD_3    = new byte[]{ 0b10011110, 94, 0b01111111 };
        public static byte[]    LEFT_TAP_QUAD_4    = new byte[]{ 0b10011110, 95, 0b01111111 };
        public static byte[]    LEFT_SWIPE_LEFT    = new byte[]{ 0, 0, 0 };
        public static byte[]    LEFT_SWIPE_RIGHT   = new byte[]{ 0b11111010, 0 ,0 };
        public static byte[]    LEFT_STOP          = new byte[]{ 0b11111100, 0, 0 };

        // Right hand MIDI command byte codes
        public static byte[]    RIGHT_TAP_QUAD_1   = new byte[]{ 0b10011010, 97, 0b01111111 };
        public static byte[]    RIGHT_TAP_QUAD_2   = new byte[]{ 0b10011010, 98, 0b01111111 };
        public static byte[]    RIGHT_TAP_QUAD_3   = new byte[]{ 0b10011010, 99, 0b01111111 };
        public static byte[]    RIGHT_TAP_QUAD_4   = new byte[]{ 0b10011010, 100, 0b01111111 };
        public static byte[]    RIGHT_SWIPE_LEFT   = new byte[]{ 0, 0, 0 };
        public static byte[]    RIGHT_SWIPE_RIGHT  = new byte[]{ 0b11111010, 0 ,0 };
        public static byte[]    RIGHT_STOP         = new byte[]{ 0b11111100, 0, 0 };
    }

    public class Commands {
        
        public Commands(bool isLeft) {
            TAP_QUAD_1  = isLeft ? CMD.LEFT_TAP_QUAD_1  : CMD.RIGHT_TAP_QUAD_1 ;
            TAP_QUAD_2  = isLeft ? CMD.LEFT_TAP_QUAD_2  : CMD.RIGHT_TAP_QUAD_2 ;
            TAP_QUAD_3  = isLeft ? CMD.LEFT_TAP_QUAD_3  : CMD.RIGHT_TAP_QUAD_3 ;
            TAP_QUAD_4  = isLeft ? CMD.LEFT_TAP_QUAD_4  : CMD.RIGHT_TAP_QUAD_4 ;
            SWIPE_LEFT  = isLeft ? CMD.LEFT_SWIPE_LEFT  : CMD.RIGHT_SWIPE_LEFT ;
            SWIPE_RIGHT = isLeft ? CMD.LEFT_SWIPE_RIGHT : CMD.RIGHT_SWIPE_RIGHT;
            STOP        = isLeft ? CMD.LEFT_STOP        : CMD.RIGHT_STOP       ;
        }

        public byte[] LookUp(int id) {
            switch (id) {
                case 1: return TAP_QUAD_1 ;
                case 2: return TAP_QUAD_2 ;
                case 3: return TAP_QUAD_3 ;
                case 4: return TAP_QUAD_4 ;
                case 5: return SWIPE_LEFT ;
                case 6: return SWIPE_RIGHT;
                case 7: return STOP       ;
                default: return null;
            }
        }

        public static byte[]    TAP_QUAD_1 ;
        public static byte[]    TAP_QUAD_2 ;
        public static byte[]    TAP_QUAD_3 ;
        public static byte[]    TAP_QUAD_4 ;
        public static byte[]    SWIPE_LEFT ;
        public static byte[]    SWIPE_RIGHT;
        public static byte[]    STOP       ;

    }
}
