
LaunchJarFile.JarLauncher jarLauncher = new LaunchJarFile.JarLauncher(@"E:\MCJava\server.jar");
jarLauncher.Run();
while (true) {
    if(Console.ReadLine() == "Stop") {
        jarLauncher.Stop();
    }
}