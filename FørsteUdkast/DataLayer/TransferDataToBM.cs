using System;


namespace DataLayer
{
    public class TransferDataToBM : ITransferDataToBm
    {
        /*
         * Her ligger alt kommunikation over internettet. Når er kaldes metoder i denne klasse,
         * er det altså for at kunne sende information til en anden computer fra raspberryPi.
         * Jeg foreslår at denne computer er client og den anden er server i denne forbindelse,
         * og den server skal så konstant vente på at blive ringet op af denne computer. Den bliver så ringet op,
         * når switchen flyttes til zeropoint eller der skal sendes info om registreret blodtryk
         */
        public void TransferZeroPointMode(bool b)
        {
            /* Denne metode skal sende besked til BM hvis den er på zero mode eller nulpunkt.
             * Der sendes altså kun information fra denne metode, når der skiftes tilstand. 
             * Alt efter tilstanden sendes true eller false?
             */
        }

        public void TransferZeroPointDone()
        {


        }

        public void TransferZeroPointStarted()
        {
            
        }

        public void TransferPatientInfo(object dto_PatientInfo)
        {
            throw new NotImplementedException();
        }

        public void ConnectToServer()
        {
            throw new NotImplementedException();
        }

        public void TransferBatteryLevel(int etb)
        {
            throw new NotImplementedException();
        }
    }
}