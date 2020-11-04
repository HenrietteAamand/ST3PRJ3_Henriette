using System;

namespace DataLayer
{
    public class UI : IUi
    {
        private bool isPressed = false; //Behøver den at have en for hver knap?
        public bool IsPressedSwitch()
        {
            return false;
        }

        public bool IsPressedStart()
        {
            while (true)
            {
                // EN MÅLING Fra RPI kanppen siger nu det nu og skifter isPressed == true;

                ReadRPI();
                if (isPressed == true)
                {
                    return true;
                }

            }
        }
        public bool IsPressedStop()
        {
            isPressed = false; // måske skal den sættes, måske det ikke nødvendigt

            // EN MÅLING Fra RPI knappen siger nu det nu og skifter isPressed == true;

            ReadRPI();
            if (isPressed == true)
            {
                return true;
            }

            return false;

        }

        public void ReadRPI()
        {
            //Ved ikke om den er nødvendig, men den måler måske noget på RPi'en..
        }

    }
}