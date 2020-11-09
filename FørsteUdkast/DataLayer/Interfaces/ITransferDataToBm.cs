
﻿namespace DataLayer
{
    public interface ITransferDataToBm
    {
        public void TransferZeroPointMode(bool b);
        public void TransferZeroPointDone();
        public void TransferZeroPointStarted();
        public void TransferPatientInfo(object dto_PatientInfo);
        public void ConnectToServer();
        public void TransferBatteryLevel(int etb);
        }
}