//
// tools:
// - vscode ( https://code.visualstudio.com/ )
// - dotnet ( https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.403-linux-x64-binaries )
//       unpack into some folder ( ie. ~/opt/dotnet ) and set ~/.bashrc PATH ( ie export PATH=$PATH:~/opt/dotnet )
//
// https://github.com/SuessLabs/Linux.Bluetooth
//

using Linux.Bluetooth;

// IAdapter1 adapter = (await BlueZManager.GetAdaptersAsync()).FirstOrDefault();

var q = await BlueZManager.GetAdaptersAsync();

if (q is not null && q.Count > 0)
{
    var adapter = q[0];

    adapter.DeviceFound += async (sender, x) =>
    {
        // var props = x.Device.GetAllAsync();
        var name = await x.Device.GetNameAsync();
        System.Console.WriteLine($"mac: {x.Device.ObjectPath} {name}");
        ;
    };

    await adapter.StartDiscoveryAsync();

    await Task.Delay(10000);

    System.Console.WriteLine("SCAN FINISHED");
}
else
    System.Console.WriteLine("no bluetooth adapters found");
