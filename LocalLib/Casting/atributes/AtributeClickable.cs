using LocalLib.Types;


namespace LocalLib.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class AttributeClickable : Attribute
    {
        
        private string attributeKey = AttributeKey.clickable;

        // private Point position;
        // private Point size;
        // private Point velocity;

        public int clicks = 0;
        public bool clickState;
        private bool toggal;
        private bool PREVEUS_State;
        private bool PREVEUS_State_2;
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public AttributeClickable()
        {
            clickState = false;
            toggal = false;
            PREVEUS_State = false;
            PREVEUS_State_2 = false;
        }

        public string GetAttributeKey()
        {
            return attributeKey;
        }

        public void toggalSwitch()
        {
            if (clickState)
            {
                PREVEUS_State_2 = PREVEUS_State;
                PREVEUS_State = toggal;
                toggal = !toggal;
            }
        }
        public bool getSwitch()
        {
            return toggal;
        }
        public bool getPREVEUS_State()
        {
            return PREVEUS_State;
        }
        public bool getPREVEUS_State_2()
        {
            return PREVEUS_State_2;
        }
    }
}