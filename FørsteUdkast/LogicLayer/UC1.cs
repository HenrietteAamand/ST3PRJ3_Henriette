using DataLayer;
namespace LogicLayer
{
    public class UC1
    {
        public IUi UserInterface { get; set; }
        public ITransferDataToBm TransferData { get; set; }
        public IBatteryLevel BatteryLevel { get; set; }
        public IZeroPointAdjustment ZeroPointAdjustment { get; set; }
        public IBloodPreassure BloodPreassure { get; set; }

        public void MakeZeroPointAdjustment()
        {
            //Tjekker om switchen ændres til nulpynktsjustering
            while (UserInterface.IsPressedSwitch() != true) {}

            //Opdaterer skærmen
            TransferData.TransferZeroPointMode(true);

            //Venter på, at der bliver trykket start
            //OBS! skal vi her også have mulighed for at ændre switch status? 
            WaitForStartPressed();
            
            TransferData.TransferZeroPointStarted();

            //Undtagelse 2: advarer om lavt batteriniveau
            //- tænker det kører i en tråd for sig? Så skal vi bare sørge for at låse metoder i TransferDataToBM så der ikke bliver synkroniseringsproblemer 

            double zeroPointValue = ZeroPointAdjustment.GetZeroPoint();
            BloodPreassure.Atm = zeroPointValue;

            TransferData.TransferZeroPointDone();
        }

        private void WaitForStartPressed()
        {
            bool isStartPressed = false;
            while (isStartPressed == false)
            {
                if (UserInterface.IsPressedStart() == true)
                {
                    isStartPressed = true;
                }
            }
        }

        public void CheckBatteryStatus()
        {

        }

        private void IsPressedSwitch()
        {
            //bool isZeroOn = false;
            while (UserInterface.IsPressedSwitch() == false)
            {
                //if (UserInterface.IsPressedSwitch() == true)
                //{
                //    isZeroOn = true;
                //}
            }
        }
    }
}