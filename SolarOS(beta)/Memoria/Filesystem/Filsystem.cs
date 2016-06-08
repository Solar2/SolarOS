using System.Collections.Generic;
using Cosmos.Hardware.BlockDevice;
using FS_Utility.HAL;

namespace SolarOS_beta_.Memoria.Filesystem
{
    internal class Filsystem
    {
        private static AtaPio ATA = null;
        private static Partition OSPartition = null;
        private static Cosmos.System.Filesystem.FAT.FatFileSystem FATS = null;
        private static List<Cosmos.System.Filesystem.Listing.Base> fatFileList; 
        public static void Inizializza()
        {
            if (BlockDevice.Devices[0] is AtaPio)
            {
                System.Console.WriteLine("Trovato dispositivo ATA");
            }
            if (BlockDevice.Devices[0] is Partition)
            {
                System.Console.WriteLine("Partizione trovata");
                OSPartition = (Partition) BlockDevice.Devices[0];
            }
        }
    }
}
