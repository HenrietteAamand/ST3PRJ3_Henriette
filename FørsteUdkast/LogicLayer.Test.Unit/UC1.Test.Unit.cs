using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NUnit.Framework;
using LogicLayer;
using DataLayer;

namespace LogicLayer.Test.Unit
{
    public class UC1_Test_Unit
    {
        private UC1 uut;
        [SetUp]
        public void Setup()
        {
            uut = new UC1();

            DummyUI DummyuserInterface = new DummyUI();
            DummyTransferData DummytransferData = new DummyTransferData();
            DummyBatteryLevel DummybatteryLevel = new DummyBatteryLevel();
            DummyZeroPointAdjustment DummyzeroPointAdjust = new DummyZeroPointAdjustment();
            DummyBloodPreassure DummyblodPreassure = new DummyBloodPreassure();

            uut.UserInterface = DummyuserInterface;
            uut.BatteryLevel = DummybatteryLevel;
            uut.BloodPreassure = DummyblodPreassure;
            uut.TransferData = DummytransferData;
            uut.ZeroPointAdjustment = DummyzeroPointAdjust;
        }

        //Syntaks: metodenavn_Scenarie_forventetResultat
        [Test]
        public void MakeZeroPointAdjustment_MockUISwitch_returnTrue()
        {
            MockUI mockUI = new MockUI();
            uut.UserInterface = mockUI;

            uut.MakeZeroPointAdjustment();
            Assert.That(mockUI.isPressedSwitch, Is.True);
        }

        [Test]
        public void MakeZeroPointAdjustment_MockTransferMode_returnTrue()
        {
            MockTransferToBM mockTransfer = new MockTransferToBM();
            uut.TransferData = mockTransfer;

            uut.MakeZeroPointAdjustment();

            Assert.That(mockTransfer.mode, Is.True);
        }

        [Test]
        public void MakeZeroPointAdjustment_MockUIWaitForStart_returnTrue()
        {
            MockUI mockUI = new MockUI();
            uut.UserInterface = mockUI;

            uut.MakeZeroPointAdjustment();

            Assert.That(mockUI.isStartPressed, Is.True);
        }

        [Test]
        public void MakeZeroPointAdjustment_MockAdjustZeropoint_return1point25()
        {
            MockZeroPointAdjusted mockZeroPointAdjusted = new MockZeroPointAdjusted();
            uut.ZeroPointAdjustment = mockZeroPointAdjusted;
            uut.MakeZeroPointAdjustment();

            Assert.That(mockZeroPointAdjusted.zeroPoint, Is.EqualTo(1.25));
        }

        [Test]
        public void MakeZeroPointAdjustment_MockBP_returnTrue()
        {
            MockBloodPreassure mockBloodPreassure= new MockBloodPreassure();
            uut.BloodPreassure = mockBloodPreassure;
            uut.MakeZeroPointAdjustment();

            Assert.That(mockBloodPreassure.isZeroPointAdjusted, Is.True);
        }

        [Test]
        public void MakeZeroPointAdjustment_MockTransferDone_returnTrue()
        {
            MockTransferToBM mockTransfer = new MockTransferToBM();
            uut.TransferData = mockTransfer;

            uut.MakeZeroPointAdjustment();

            Assert.That(mockTransfer.done, Is.True);
        }


        class MockUI : IUi
        {
            public bool isPressedSwitch = false;
            public bool isStartPressed = false;

            public bool IsPressedSwitch()
            {
                isPressedSwitch = true;
                return isPressedSwitch;
            }

            public bool IsPressedStart()
            {
                return true;
            }

            public bool WaitForStartPressed()
            {
                isStartPressed = true;
                return isStartPressed;
            }
        }

        class MockTransferToBM : ITransferDataToBm
        {
            public bool mode = false;
            public bool done = false;
            public void TransferZeroPointMode(bool b)
            {
                mode = true;
            }
            public void TransferZeroPointDone()
            {
                done = true;
            }

            public void TransferPatientInfo(object dto_PatientInfo)
            {
                
            }

            public void ConnectToServer()
            {
            }

            public void TransferBatteryLevel(int etb)
            {
            }
        }

        class MockBloodPreassure : IBloodPreassure
        {
            public bool isZeroPointAdjusted = false;
            public void AdjustZeroPoint(double zeropointValue)
            {
                isZeroPointAdjusted = true;
            }
        }

        class MockZeroPointAdjusted : IZeroPointAdjustment
        {
            public double zeroPoint = 0;
            public double GetZeroPoint()
            {
                zeroPoint = 1.25;
                return zeroPoint;
            }
        }

        

        //Dummys
        class DummyUI : IUi
        {
            public bool IsPressedSwitch()
            {
                return true;
            }

            public bool IsPressedStart()
            {
                return true;
            }

            public bool WaitForStartPressed()
            {
                return true;
            }
        }
        class DummyTransferData : ITransferDataToBm
        {
            public void TransferZeroPointMode(bool b)
            {
                
            }

            public void TransferZeroPointDone()
            {
                
            }

            public void TransferPatientInfo(object dto_PatientInfo)
            {
                
            }

            public void ConnectToServer()
            {
            }

            public void TransferBatteryLevel(int etb)
            {
            }
        }
        class DummyBatteryLevel : IBatteryLevel
        {

        }
        class DummyZeroPointAdjustment : IZeroPointAdjustment
        {
            public double GetZeroPoint()
            {
                return 1;
            }
        }
        class DummyBloodPreassure : IBloodPreassure
        {
            public void AdjustZeroPoint(double zeropintValue)
            {
            }
        }
    }
}
