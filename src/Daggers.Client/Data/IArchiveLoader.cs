namespace Daggers.Client.Data
{
    interface IArchiveLoader<out TAsset> where TAsset : IAsset
    {
        TAsset Load(string filename);
    }
}
