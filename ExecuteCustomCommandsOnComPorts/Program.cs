using System.IO.Ports;

string[] portNames = SerialPort.GetPortNames();

if (portNames.Length == 0)
{
    Console.WriteLine("No COM ports are available.");
}
else
{
    //Send Command to all available ports
    foreach (var portName in SerialPort.GetPortNames())
    {
        //you can apply condition for your specific port
        try
        {
            using var port = new SerialPort(portName);
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.ReadTimeout = 10;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write("Command");
            Console.WriteLine("Command");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking {portName}: {ex.Message}");
        }
    }
}