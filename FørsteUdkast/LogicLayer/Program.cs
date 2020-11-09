using Microsoft.VisualBasic.CompilerServices;
using DataLayer;

namespace LogicLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opretter alle klassserne
            UC1 useCase1Controller = new UC1();
            UI userInterface = new UI();
            TransferDataToBM transferData = new TransferDataToBM();
            BatteryLevel batteryLevel = new BatteryLevel();
            ZeroPointAdjustment zeroPointAdjust = new ZeroPointAdjustment();
            BloodPressure blodPreassure = new BloodPressure();
            ITransducer transducer = new Transducer();

            zeroPointAdjust.Transducer = transducer;

            //Tildeler de rigtige properties til UC1
            useCase1Controller.UserInterface = userInterface;
            useCase1Controller.TransferData = transferData;
            useCase1Controller.BatteryLevel = batteryLevel;
            useCase1Controller.ZeroPointAdjustment = zeroPointAdjust;
            useCase1Controller.BloodPreassure = blodPreassure;
            
            //Det ene thread skal kalde denne metode
            useCase1Controller.MakeZeroPointAdjustment();
            
            //Det andet thread skal kalde denne metode
            useCase1Controller.CheckBatteryStatus();



            /*
             * Her skal så oprettes to threads. Det ene thread skal læse batterylevel
             * og det andet skal foretage en måling
             * Jeg løser det ved at lave 
             */


        }
    }
}
