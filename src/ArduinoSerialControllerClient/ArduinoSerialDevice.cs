using System;
using System.Threading;
using duinocom;

namespace ArduinoSerialControllerClient
{
    public class ArduinoSerialDevice
    {
        public SerialClient Client;

        public bool IsConnected = false;

        public string ArduinoSerialControllerSketchTitle = "ArduinoSerialController";

        public bool IsDebug = false;

        public ArduinoSerialDevice (string portName, int baudRate)
        {
            Client = new SerialClient (portName, baudRate);
        }

        public void Connect ()
        {
            Client.Open ();

            IsConnected = true;

            // Read the first line (the title) to clear the buffer
            Client.ReadLine ();
        }

        public void Disconnect ()
        {
            Client.Close ();

            IsConnected = false;
        }

        public bool DigitalRead (int pinNumber)
        {
            var cmd = String.Format ("D{0}:R", pinNumber);

            Client.WriteLine (cmd);

            var output = String.Empty;
            while (output == String.Empty || output == ArduinoSerialControllerSketchTitle) {
                output = Client.ReadLine ().Trim ();
            }

            var digitalValue = 0;
            if (!Int32.TryParse (output, out digitalValue))
                throw new Exception ("Failed to convert digital pin value: " + output);

            return digitalValue == 1;
        }

        public int AnalogRead (int pinNumber)
        {
            var cmd = String.Format ("A{0}:R", pinNumber);

            Client.WriteLine (cmd);

            var output = String.Empty;
            while (output == String.Empty || output == ArduinoSerialControllerSketchTitle) {
                output = Client.ReadLine ().Trim ();
            }

            var analogValue = 0;
            if (!Int32.TryParse (output, out analogValue))
                throw new Exception ("Failed to convert analog pin value: " + output);

            return analogValue;
        }

        public void DigitalWrite (int pinNumber, bool value)
        {
            var cmd = String.Format ("A{0}:{1}", pinNumber, value);

            Client.WriteLine (cmd);
        }

        public void AnalogWrite (int pinNumber, int value)
        {
            var cmd = String.Format ("A{0}:{1}", pinNumber, value);

            Client.WriteLine (cmd);
        }

        public void AnalogWritePercentage (int pinNumber, int value)
        {
            CheckConnected ();

            if (IsDebug)
                Console.WriteLine ("Analog writing percentage: " + value);

            var pwmValue = ArduinoConvert.PercentageToPWM (value);

            if (IsDebug)
                Console.WriteLine ("Converted PWM value: " + pwmValue);

            var cmd = String.Format ("A{0}:{1}", pinNumber, pwmValue);

            if (IsDebug)
                Console.WriteLine ("Sending command: " + cmd);
            
            Client.WriteLine (cmd);
        }

        public void PinMode (int pinNumber, PinMode pinMode)
        {
            CheckConnected ();

            if (IsDebug) {
                Console.WriteLine ("Setting pin mode...");
                Console.WriteLine ("  Pin number: " + pinNumber);
                Console.WriteLine ("  Pin mode: " + pinMode.ToString ());
            }

            var cmd = String.Format ("M{0}:{1}", pinNumber, (int)pinMode);

            if (IsDebug)
                Console.WriteLine ("Sending command: " + cmd);

            Client.WriteLine (cmd);

        }

        public void CheckConnected ()
        {
            if (!IsConnected)
                throw new Exception ("Not connected. Call Connect() function before trying to communicate.");
        }
    }
}
