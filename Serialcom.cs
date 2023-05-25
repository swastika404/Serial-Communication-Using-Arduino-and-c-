using System;
using System.IO.Ports;

class Program
{
    static SerialPort arduinoPort;
    static bool isArduinoConnected = false;

    static void Main(string[] args)
    {
        // Create a new SerialPort object with the appropriate settings
        arduinoPort = new SerialPort("COM4", 9600);
        arduinoPort.DataReceived += ArduinoDataReceived;

        // Try to establish the initial connection with Arduino
        EstablishConnection();

        // Continuously check if Arduino is connected
        while (true)
        {
            if (IsArduinoConnected())
            {
                Console.WriteLine("Arduino is connected.");
                // Perform actions when Arduino is connected
            }
            else
            {
                Console.WriteLine("Arduino is disconnected.");
                EstablishConnection();
                // Perform actions when Arduino is disconnected
            }

            // Delay before checking the connection again
            System.Threading.Thread.Sleep(1000);
        }
    }

    static void EstablishConnection()
    {
        try
        {
            // Open the serial port
            arduinoPort.Open();
            isArduinoConnected = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to connect to Arduino: " + ex.Message);
            isArduinoConnected = false;
        }
    }

    static bool IsArduinoConnected()
    {
        return arduinoPort.IsOpen && isArduinoConnected;
    }

    static void ArduinoDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (IsArduinoConnected())
        {
            // Read the incoming data from Arduino
            string data = arduinoPort.ReadLine();

            // Process the data as needed
            Console.WriteLine("Received data from Arduino: " + data);
        }
    }
}
