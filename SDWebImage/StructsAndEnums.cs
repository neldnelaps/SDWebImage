using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SDWebImage
{
    public enum FLLogLevel : uint
    {
        None = 0,
        Error,
        Warn,
        Info,
        Debug,
        Verbose
    }

    static class CFunctions
    {
        [DllImport("__Internal")]
        static extern UIImage SDScaledImageForKey(NSString key, UIImage image);
    }

    public enum SDWebImageDownloaderOptions : uint
    {
        LowPriority = 1 << 0,
        ProgressiveDownload = 1 << 1,
        UseNSURLCache = 1 << 2,
        IgnoreCachedResponse = 1 << 3,
        ContinueInBackground = 1 << 4,
        HandleCookies = 1 << 5,
        AllowInvalidSSLCertificates = 1 << 6,
        HighPriority = 1 << 7,
        ScaleDownLargeImages = 1 << 8
    }

    public enum SDWebImageDownloaderExecutionOrder : uint
    {
        FIFOExecutionOrder,
        LIFOExecutionOrder
    }

    public enum SDImageCacheType : uint
    {
        None,
        Disk,
        Memory
    }

    public enum SDWebImageOptions : uint
    {
        RetryFailed = 1 << 0,
        LowPriority = 1 << 1,
        CacheMemoryOnly = 1 << 2,
        ProgressiveDownload = 1 << 3,
        RefreshCached = 1 << 4,
        ContinueInBackground = 1 << 5,
        HandleCookies = 1 << 6,
        AllowInvalidSSLCertificates = 1 << 7,
        HighPriority = 1 << 8,
        DelayPlaceholder = 1 << 9,
        TransformAnimatedImage = 1 << 10,
        AvoidAutoSetImage = 1 << 11,
        ScaleDownLargeImages = 1 << 12
    }

    public enum SDImageFormat : int
    {
        Undefined = -1,
        Jpeg = 0,
        Png,
        Gif,
        Tiff,
        WebP
    }
}