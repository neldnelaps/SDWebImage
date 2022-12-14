using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using MapKit;
using ObjCRuntime;
using UIKit;

namespace SDWebImage
{
    // @interface FLAnimatedImageView : UIImageView
    [BaseType(typeof(UIImageView))]
    interface FLAnimatedImageView
    {
        // @property (nonatomic, strong) FLAnimatedImage * animatedImage;
        [Export("animatedImage", ArgumentSemantic.Strong)]
        FLAnimatedImage AnimatedImage { get; set; }

        // @property (copy, nonatomic) void (^loopCompletionBlock)(NSUInteger);
        [Export("loopCompletionBlock", ArgumentSemantic.Copy)]
        Action<nuint> LoopCompletionBlock { get; set; }

        // @property (readonly, nonatomic, strong) UIImage * currentFrame;
        [Export("currentFrame", ArgumentSemantic.Strong)]
        UIImage CurrentFrame { get; }

        // @property (readonly, assign, nonatomic) NSUInteger currentFrameIndex;
        [Export("currentFrameIndex")]
        nuint CurrentFrameIndex { get; }

        // @property (copy, nonatomic) NSString * runLoopMode;
        [Export("runLoopMode")]
        string RunLoopMode { get; set; }
    }

    // @interface FLAnimatedImage : NSObject
    [BaseType(typeof(NSObject))]
    interface FLAnimatedImage
    {
        // @property (readonly, nonatomic, strong) UIImage * posterImage;
        [Export("posterImage", ArgumentSemantic.Strong)]
        UIImage PosterImage { get; }

        // @property (readonly, assign, nonatomic) CGSize size;
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size { get; }

        // @property (readonly, assign, nonatomic) NSUInteger loopCount;
        [Export("loopCount")]
        nuint LoopCount { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * delayTimesForIndexes;
        [Export("delayTimesForIndexes", ArgumentSemantic.Strong)]
        NSDictionary DelayTimesForIndexes { get; }

        // @property (readonly, assign, nonatomic) NSUInteger frameCount;
        [Export("frameCount")]
        nuint FrameCount { get; }

        // @property (readonly, assign, nonatomic) NSUInteger frameCacheSizeCurrent;
        [Export("frameCacheSizeCurrent")]
        nuint FrameCacheSizeCurrent { get; }

        // @property (assign, nonatomic) NSUInteger frameCacheSizeMax;
        [Export("frameCacheSizeMax")]
        nuint FrameCacheSizeMax { get; set; }

        // -(UIImage *)imageLazilyCachedAtIndex:(NSUInteger)index;
        [Export("imageLazilyCachedAtIndex:")]
        UIImage ImageLazilyCachedAtIndex(nuint index);

        // +(CGSize)sizeForImage:(id)image;
        [Static]
        [Export("sizeForImage:")]
        CGSize SizeForImage(NSObject image);

        // -(instancetype)initWithAnimatedGIFData:(NSData *)data;
        [Export("initWithAnimatedGIFData:")]
        IntPtr Constructor(NSData data);

        // -(instancetype)initWithAnimatedGIFData:(NSData *)data optimalFrameCacheSize:(NSUInteger)optimalFrameCacheSize predrawingEnabled:(BOOL)isPredrawingEnabled __attribute__((objc_designated_initializer));
        [Export("initWithAnimatedGIFData:optimalFrameCacheSize:predrawingEnabled:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSData data, nuint optimalFrameCacheSize, bool isPredrawingEnabled);

        // +(instancetype)animatedImageWithGIFData:(NSData *)data;
        [Static]
        [Export("animatedImageWithGIFData:")]
        FLAnimatedImage AnimatedImageWithGIFData(NSData data);

        // @property (readonly, nonatomic, strong) NSData * data;
        [Export("data", ArgumentSemantic.Strong)]
        NSData Data { get; }
    }

    // @interface Logging (FLAnimatedImage)
    [Category]
    [BaseType(typeof(FLAnimatedImage))]
    interface FLAnimatedImage_Logging
    {
        // +(void)setLogBlock:(void (^)(NSString *, FLLogLevel))logBlock logLevel:(FLLogLevel)logLevel;
        [Static]
        [Export("setLogBlock:logLevel:")]
        void SetLogBlock(Action<NSString, FLLogLevel> logBlock, FLLogLevel logLevel);

        // +(void)logStringFromBlock:(NSString *(^)(void))stringBlock withLevel:(FLLogLevel)level;
        [Static]
        [Export("logStringFromBlock:withLevel:")]
        void LogStringFromBlock(Func<NSString> stringBlock, FLLogLevel level);
    }

    // typedef void (^SDWebImageNoParamsBlock)();
    delegate void SDWebImageNoParamsBlock();

    interface ISDWebImageOperation { }

    // @protocol SDWebImageOperation <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImageOperation
    {
        // @required -(void)cancel;
        [Abstract]
        [Export("cancel")]
        void Cancel();
    }

    // typedef void (^SDWebImageDownloaderProgressBlock)(NSInteger, NSInteger, NSURL * _Nullable);
    delegate void SDWebImageDownloaderProgressBlock(nint arg0, nint arg1, [NullAllowed] NSUrl arg2);

    // typedef void (^SDWebImageDownloaderCompletedBlock)(UIImage * _Nullable, NSData * _Nullable, NSError * _Nullable, BOOL);
    delegate void SDWebImageDownloaderCompletedBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, [NullAllowed] NSError arg2, bool arg3);

    //// typedef SDHTTPHeadersDictionary * _Nullable (^SDWebImageDownloaderHeadersFilterBlock)(NSURL * _Nullable, SDHTTPHeadersDictionary * _Nullable);
    //delegate NSDictionary<NSString, NSString> SDWebImageDownloaderHeadersFilterBlock([NullAllowed] NSUrl arg0, [NullAllowed] NSDictionary<NSString, NSString> arg1);

    // @interface SDWebImageDownloadToken : NSObject
    [BaseType(typeof(NSObject))]
    interface SDWebImageDownloadToken
    {
        // @property (nonatomic, strong) NSURL * _Nullable url;
        [NullAllowed, Export("url", ArgumentSemantic.Strong)]
        NSUrl Url { get; set; }

        // @property (nonatomic, strong) id _Nullable downloadOperationCancelToken;
        [NullAllowed, Export("downloadOperationCancelToken", ArgumentSemantic.Strong)]
        NSObject DownloadOperationCancelToken { get; set; }
    }

    // @interface SDWebImageDownloader : NSObject
    [BaseType(typeof(NSObject))]
    interface SDWebImageDownloader
    {
        // @property (assign, nonatomic) BOOL shouldDecompressImages;
        [Export("shouldDecompressImages")]
        bool ShouldDecompressImages { get; set; }

        // @property (assign, nonatomic) NSInteger maxConcurrentDownloads;
        [Export("maxConcurrentDownloads")]
        nint MaxConcurrentDownloads { get; set; }

        // @property (readonly, nonatomic) NSUInteger currentDownloadCount;
        [Export("currentDownloadCount")]
        nuint CurrentDownloadCount { get; }

        // @property (assign, nonatomic) NSTimeInterval downloadTimeout;
        [Export("downloadTimeout")]
        double DownloadTimeout { get; set; }

        // @property (assign, nonatomic) SDWebImageDownloaderExecutionOrder executionOrder;
        [Export("executionOrder", ArgumentSemantic.Assign)]
        SDWebImageDownloaderExecutionOrder ExecutionOrder { get; set; }

        // +(instancetype _Nonnull)sharedDownloader;
        [Static]
        [Export("sharedDownloader")]
        SDWebImageDownloader SharedDownloader();

        // @property (nonatomic, strong) NSURLCredential * _Nullable urlCredential;
        [NullAllowed, Export("urlCredential", ArgumentSemantic.Strong)]
        NSUrlCredential UrlCredential { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable username;
        [NullAllowed, Export("username", ArgumentSemantic.Strong)]
        string Username { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable password;
        [NullAllowed, Export("password", ArgumentSemantic.Strong)]
        string Password { get; set; }

        //// @property (copy, nonatomic) SDWebImageDownloaderHeadersFilterBlock _Nullable headersFilter;
        //[NullAllowed, Export("headersFilter", ArgumentSemantic.Copy)]
        //SDWebImageDownloaderHeadersFilterBlock HeadersFilter { get; set; }

        // -(instancetype _Nonnull)initWithSessionConfiguration:(NSURLSessionConfiguration * _Nullable)sessionConfiguration __attribute__((objc_designated_initializer));
        [Export("initWithSessionConfiguration:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] NSUrlSessionConfiguration sessionConfiguration);

        // -(void)setValue:(NSString * _Nullable)value forHTTPHeaderField:(NSString * _Nullable)field;
        [Export("setValue:forHTTPHeaderField:")]
        void SetValue([NullAllowed] string value, [NullAllowed] string field);

        // -(NSString * _Nullable)valueForHTTPHeaderField:(NSString * _Nullable)field;
        [Export("valueForHTTPHeaderField:")]
        [return: NullAllowed]
        string ValueForHTTPHeaderField([NullAllowed] string field);

        // -(void)setOperationClass:(Class _Nullable)operationClass;
        [Export("setOperationClass:")]
        void SetOperationClass([NullAllowed] Class operationClass);

        // -(SDWebImageDownloadToken * _Nullable)downloadImageWithURL:(NSURL * _Nullable)url options:(SDWebImageDownloaderOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDWebImageDownloaderCompletedBlock _Nullable)completedBlock;
        [Export("downloadImageWithURL:options:progress:completed:")]
        [return: NullAllowed]
        SDWebImageDownloadToken DownloadImageWithURL([NullAllowed] NSUrl url, SDWebImageDownloaderOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDWebImageDownloaderCompletedBlock completedBlock);

        // -(void)cancel:(SDWebImageDownloadToken * _Nullable)token;
        [Export("cancel:")]
        void Cancel([NullAllowed] SDWebImageDownloadToken token);

        // -(void)setSuspended:(BOOL)suspended;
        [Export("setSuspended:")]
        void SetSuspended(bool suspended);

        // -(void)cancelAllDownloads;
        [Export("cancelAllDownloads")]
        void CancelAllDownloads();
    }

    // typedef void (^SDCacheQueryCompletedBlock)(UIImage * _Nullable, NSData * _Nullable, SDImageCacheType);
    delegate void SDCacheQueryCompletedBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, SDImageCacheType arg2);

    // typedef void (^SDWebImageCheckCacheCompletionBlock)(BOOL);
    delegate void SDWebImageCheckCacheCompletionBlock(bool arg0);

    // typedef void (^SDWebImageCalculateSizeBlock)(NSUInteger, NSUInteger);
    delegate void SDWebImageCalculateSizeBlock(nuint arg0, nuint arg1);

    // @interface SDImageCache : NSObject
    [BaseType(typeof(NSObject))]
    interface SDImageCache
    {
        // @property (readonly, nonatomic) SDImageCacheConfig * _Nonnull config;
        [Export("config")]
        SDImageCacheConfig Config { get; }

        // @property (assign, nonatomic) NSUInteger maxMemoryCost;
        [Export("maxMemoryCost")]
        nuint MaxMemoryCost { get; set; }

        // @property (assign, nonatomic) NSUInteger maxMemoryCountLimit;
        [Export("maxMemoryCountLimit")]
        nuint MaxMemoryCountLimit { get; set; }

        // +(instancetype _Nonnull)sharedImageCache;
        [Static]
        [Export("sharedImageCache")]
        SDImageCache SharedImageCache { get; }

        // -(instancetype _Nonnull)initWithNamespace:(NSString * _Nonnull)ns;
        [Export("initWithNamespace:")]
        IntPtr Constructor(string ns);

        // -(instancetype _Nonnull)initWithNamespace:(NSString * _Nonnull)ns diskCacheDirectory:(NSString * _Nonnull)directory __attribute__((objc_designated_initializer));
        [Export("initWithNamespace:diskCacheDirectory:")]
        [DesignatedInitializer]
        IntPtr Constructor(string ns, string directory);

        // -(NSString * _Nullable)makeDiskCachePath:(NSString * _Nonnull)fullNamespace;
        [Export("makeDiskCachePath:")]
        [return: NullAllowed]
        string MakeDiskCachePath(string fullNamespace);

        // -(void)addReadOnlyCachePath:(NSString * _Nonnull)path;
        [Export("addReadOnlyCachePath:")]
        void AddReadOnlyCachePath(string path);

        // -(void)storeImage:(UIImage * _Nullable)image forKey:(NSString * _Nullable)key completion:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("storeImage:forKey:completion:")]
        void StoreImage([NullAllowed] UIImage image, [NullAllowed] string key, [NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(void)storeImage:(UIImage * _Nullable)image forKey:(NSString * _Nullable)key toDisk:(BOOL)toDisk completion:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("storeImage:forKey:toDisk:completion:")]
        void StoreImage([NullAllowed] UIImage image, [NullAllowed] string key, bool toDisk, [NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(void)storeImage:(UIImage * _Nullable)image imageData:(NSData * _Nullable)imageData forKey:(NSString * _Nullable)key toDisk:(BOOL)toDisk completion:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("storeImage:imageData:forKey:toDisk:completion:")]
        void StoreImage([NullAllowed] UIImage image, [NullAllowed] NSData imageData, [NullAllowed] string key, bool toDisk, [NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(void)storeImageDataToDisk:(NSData * _Nullable)imageData forKey:(NSString * _Nullable)key;
        [Export("storeImageDataToDisk:forKey:")]
        void StoreImageDataToDisk([NullAllowed] NSData imageData, [NullAllowed] string key);

        // -(void)diskImageExistsWithKey:(NSString * _Nullable)key completion:(SDWebImageCheckCacheCompletionBlock _Nullable)completionBlock;
        [Export("diskImageExistsWithKey:completion:")]
        void DiskImageExists([NullAllowed] string key, [NullAllowed] SDWebImageCheckCacheCompletionBlock completionBlock);

        // -(NSOperation * _Nullable)queryCacheOperationForKey:(NSString * _Nullable)key done:(SDCacheQueryCompletedBlock _Nullable)doneBlock;
        [Export("queryCacheOperationForKey:done:")]
        [return: NullAllowed]
        NSOperation QueryCacheOperation([NullAllowed] string key, [NullAllowed] SDCacheQueryCompletedBlock doneBlock);

        // -(UIImage * _Nullable)imageFromMemoryCacheForKey:(NSString * _Nullable)key;
        [Export("imageFromMemoryCacheForKey:")]
        [return: NullAllowed]
        UIImage ImageFromMemoryCache([NullAllowed] string key);

        // -(UIImage * _Nullable)imageFromDiskCacheForKey:(NSString * _Nullable)key;
        [Export("imageFromDiskCacheForKey:")]
        [return: NullAllowed]
        UIImage ImageFromDiskCache([NullAllowed] string key);

        // -(UIImage * _Nullable)imageFromCacheForKey:(NSString * _Nullable)key;
        [Export("imageFromCacheForKey:")]
        [return: NullAllowed]
        UIImage ImageFromCache([NullAllowed] string key);

        // -(void)removeImageForKey:(NSString * _Nullable)key withCompletion:(SDWebImageNoParamsBlock _Nullable)completion;
        [Export("removeImageForKey:withCompletion:")]
        void RemoveImage([NullAllowed] string key, [NullAllowed] SDWebImageNoParamsBlock completion);

        // -(void)removeImageForKey:(NSString * _Nullable)key fromDisk:(BOOL)fromDisk withCompletion:(SDWebImageNoParamsBlock _Nullable)completion;
        [Export("removeImageForKey:fromDisk:withCompletion:")]
        void RemoveImage([NullAllowed] string key, bool fromDisk, [NullAllowed] SDWebImageNoParamsBlock completion);

        // -(void)clearMemory;
        [Export("clearMemory")]
        void ClearMemory();

        // -(void)clearDiskOnCompletion:(SDWebImageNoParamsBlock _Nullable)completion;
        [Export("clearDiskOnCompletion:")]
        void ClearDiskOnCompletion([NullAllowed] SDWebImageNoParamsBlock completion);

        // -(void)deleteOldFilesWithCompletionBlock:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("deleteOldFilesWithCompletionBlock:")]
        void DeleteOldFilesWithCompletionBlock([NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(NSUInteger)getSize;
        [Export("getSize")]
        nuint Size { get; }

        // -(NSUInteger)getDiskCount;
        [Export("getDiskCount")]
        nuint DiskCount { get; }

        // -(void)calculateSizeWithCompletionBlock:(SDWebImageCalculateSizeBlock _Nullable)completionBlock;
        [Export("calculateSizeWithCompletionBlock:")]
        void CalculateSizeWithCompletionBlock([NullAllowed] SDWebImageCalculateSizeBlock completionBlock);

        // -(NSString * _Nullable)cachePathForKey:(NSString * _Nullable)key inPath:(NSString * _Nonnull)path;
        [Export("cachePathForKey:inPath:")]
        [return: NullAllowed]
        string CachePathForKey([NullAllowed] string key, string path);

        // -(NSString * _Nullable)defaultCachePathForKey:(NSString * _Nullable)key;
        [Export("defaultCachePathForKey:")]
        [return: NullAllowed]
        string DefaultCachePathForKey([NullAllowed] string key);
    }

    // typedef void (^SDExternalCompletionBlock)(UIImage * _Nullable, NSError * _Nullable, SDImageCacheType, NSURL * _Nullable);
    delegate void SDExternalCompletionBlock([NullAllowed] UIImage arg0, [NullAllowed] NSError arg1, SDImageCacheType arg2, [NullAllowed] NSUrl arg3);

    // typedef void (^SDInternalCompletionBlock)(UIImage * _Nullable, NSData * _Nullable, NSError * _Nullable, SDImageCacheType, BOOL, NSURL * _Nullable);
    delegate void SDInternalCompletionBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, [NullAllowed] NSError arg2, SDImageCacheType arg3, bool arg4, [NullAllowed] NSUrl arg5);

    // typedef NSString * _Nullable (^SDWebImageCacheKeyFilterBlock)(NSURL * _Nullable);
    delegate string SDWebImageCacheKeyFilterBlock([NullAllowed] NSUrl arg0);

    // @protocol SDWebImageManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImageManagerDelegate
    {
        // @optional -(BOOL)imageManager:(SDWebImageManager * _Nonnull)imageManager shouldDownloadImageForURL:(NSURL * _Nullable)imageURL;
        [Export("imageManager:shouldDownloadImageForURL:")]
        bool ImageManager(SDWebImageManager imageManager, [NullAllowed] NSUrl imageURL);

        // @optional -(UIImage * _Nullable)imageManager:(SDWebImageManager * _Nonnull)imageManager transformDownloadedImage:(UIImage * _Nullable)image withURL:(NSURL * _Nullable)imageURL;
        [Export("imageManager:transformDownloadedImage:withURL:")]
        [return: NullAllowed]
        UIImage ImageManager(SDWebImageManager imageManager, [NullAllowed] UIImage image, [NullAllowed] NSUrl imageURL);
    }

    // @interface SDWebImageManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SDWebImageManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SDWebImageManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SDWebImageManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) SDImageCache * _Nullable imageCache;
        [NullAllowed, Export("imageCache", ArgumentSemantic.Strong)]
        SDImageCache ImageCache { get; }

        // @property (readonly, nonatomic, strong) SDWebImageDownloader * _Nullable imageDownloader;
        [NullAllowed, Export("imageDownloader", ArgumentSemantic.Strong)]
        SDWebImageDownloader ImageDownloader { get; }

        // @property (copy, nonatomic) SDWebImageCacheKeyFilterBlock _Nullable cacheKeyFilter;
        [NullAllowed, Export("cacheKeyFilter", ArgumentSemantic.Copy)]
        SDWebImageCacheKeyFilterBlock CacheKeyFilter { get; set; }

        // +(instancetype _Nonnull)sharedManager;
        [Static]
        [Export("sharedManager")]
        SDWebImageManager SharedManager { get; }

        // -(instancetype _Nonnull)initWithCache:(SDImageCache * _Nonnull)cache downloader:(SDWebImageDownloader * _Nonnull)downloader __attribute__((objc_designated_initializer));
        [Export("initWithCache:downloader:")]
        [DesignatedInitializer]
        IntPtr Constructor(SDImageCache cache, SDWebImageDownloader downloader);

        // -(id<SDWebImageOperation> _Nullable)loadImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDInternalCompletionBlock _Nullable)completedBlock;
        [Export("loadImageWithURL:options:progress:completed:")]
        [return: NullAllowed]
        ISDWebImageOperation LoadImageWithURL([NullAllowed] NSUrl url, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDInternalCompletionBlock completedBlock);

        // -(void)saveImageToCache:(UIImage * _Nullable)image forURL:(NSURL * _Nullable)url;
        [Export("saveImageToCache:forURL:")]
        void SaveImageToCache([NullAllowed] UIImage image, [NullAllowed] NSUrl url);

        // -(void)cancelAll;
        [Export("cancelAll")]
        void CancelAll();

        // -(BOOL)isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // -(void)cachedImageExistsForURL:(NSURL * _Nullable)url completion:(SDWebImageCheckCacheCompletionBlock _Nullable)completionBlock;
        [Export("cachedImageExistsForURL:completion:")]
        void CachedImageExistsForURL([NullAllowed] NSUrl url, [NullAllowed] SDWebImageCheckCacheCompletionBlock completionBlock);

        // -(void)diskImageExistsForURL:(NSURL * _Nullable)url completion:(SDWebImageCheckCacheCompletionBlock _Nullable)completionBlock;
        [Export("diskImageExistsForURL:completion:")]
        void DiskImageExistsForURL([NullAllowed] NSUrl url, [NullAllowed] SDWebImageCheckCacheCompletionBlock completionBlock);

        // -(NSString * _Nullable)cacheKeyForURL:(NSURL * _Nullable)url;
        [Export("cacheKeyForURL:")]
        [return: NullAllowed]
        string CacheKeyForURL([NullAllowed] NSUrl url);
    }

    // @interface WebCache (FLAnimatedImageView)
    [Category]
    [BaseType(typeof(FLAnimatedImageView))]
    interface FLAnimatedImageView_WebCache
    {
        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url;
        [Export("sd_setImageWithURL:")]
        void SetImage([NullAllowed] NSUrl url);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setImageWithURL:placeholderImage:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setImageWithURL:placeholderImage:options:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:options:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:options:progress:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);
    }

    // @interface WebCache (MKAnnotationView)
    [Category]
    [BaseType(typeof(MKAnnotationView))]
    interface MKAnnotationView_WebCache
    {
        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url;
        [Export("sd_setImageWithURL:")]
        void SetImage([NullAllowed] NSUrl url);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setImageWithURL:placeholderImage:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setImageWithURL:placeholderImage:options:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:options:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);
    }

    // @interface ImageContentType (NSData)
    [Category]
    [BaseType(typeof(NSData))]
    interface NSData_ImageContentType
    {
        // +(SDImageFormat)sd_imageFormatForImageData:(NSData * _Nullable)data;
        [Static]
        [Export("sd_imageFormatForImageData:")]
        SDImageFormat ImageFormatForImageData([NullAllowed] NSData data);
    }

    // @interface SDImageCacheConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface SDImageCacheConfig
    {
        // @property (assign, nonatomic) BOOL shouldDecompressImages;
        [Export("shouldDecompressImages")]
        bool ShouldDecompressImages { get; set; }

        // @property (assign, nonatomic) BOOL shouldDisableiCloud;
        [Export("shouldDisableiCloud")]
        bool ShouldDisableiCloud { get; set; }

        // @property (assign, nonatomic) BOOL shouldCacheImagesInMemory;
        [Export("shouldCacheImagesInMemory")]
        bool ShouldCacheImagesInMemory { get; set; }

        // @property (assign, nonatomic) NSInteger maxCacheAge;
        [Export("maxCacheAge")]
        nint MaxCacheAge { get; set; }

        // @property (assign, nonatomic) NSUInteger maxCacheSize;
        [Export("maxCacheSize")]
        nuint MaxCacheSize { get; set; }
    }

    // @interface ForceDecode (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_ForceDecode
    {
        // +(UIImage * _Nullable)decodedImageWithImage:(UIImage * _Nullable)image;
        [Static]
        [Export("decodedImageWithImage:")]
        [return: NullAllowed]
        UIImage DecodedImageWithImage([NullAllowed] UIImage image);

        // +(UIImage * _Nullable)decodedAndScaledDownImageWithImage:(UIImage * _Nullable)image;
        [Static]
        [Export("decodedAndScaledDownImageWithImage:")]
        [return: NullAllowed]
        UIImage DecodedAndScaledDownImageWithImage([NullAllowed] UIImage image);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull SDWebImageDownloadStartNotification;
        [Field("SDWebImageDownloadStartNotification", "__Internal")]
        NSString SDWebImageDownloadStartNotification { get; }

        // extern NSString *const _Nonnull SDWebImageDownloadReceiveResponseNotification;
        [Field("SDWebImageDownloadReceiveResponseNotification", "__Internal")]
        NSString SDWebImageDownloadReceiveResponseNotification { get; }

        // extern NSString *const _Nonnull SDWebImageDownloadStopNotification;
        [Field("SDWebImageDownloadStopNotification", "__Internal")]
        NSString SDWebImageDownloadStopNotification { get; }

        // extern NSString *const _Nonnull SDWebImageDownloadFinishNotification;
        [Field("SDWebImageDownloadFinishNotification", "__Internal")]
        NSString SDWebImageDownloadFinishNotification { get; }

        // extern NSString *const SDWebImageErrorDomain;
        [Field("SDWebImageErrorDomain", "__Internal")]
        NSString SDWebImageErrorDomain { get; }

        // extern const NSTimeInterval kFLAnimatedImageDelayTimeIntervalMinimum;
        [Field("kFLAnimatedImageDelayTimeIntervalMinimum", "__Internal")]
        double kFLAnimatedImageDelayTimeIntervalMinimum { get; }
    }

    // @protocol SDWebImageDownloaderOperationInterface <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImageDownloaderOperationInterface
    {
        // @required -(instancetype _Nonnull)initWithRequest:(NSURLRequest * _Nullable)request inSession:(NSURLSession * _Nullable)session options:(SDWebImageDownloaderOptions)options;
        [Export("initWithRequest:inSession:options:")]
        IntPtr Constructor([NullAllowed] NSUrlRequest request, [NullAllowed] NSUrlSession session, SDWebImageDownloaderOptions options);

        // @required -(id _Nullable)addHandlersForProgress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDWebImageDownloaderCompletedBlock _Nullable)completedBlock;
        [Export("addHandlersForProgress:completed:")]
        [return: NullAllowed]
        NSObject AddHandlersForProgress([NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDWebImageDownloaderCompletedBlock completedBlock);

        // @required -(BOOL)shouldDecompressImages;
        // @required -(void)setShouldDecompressImages:(BOOL)value;
        [Export("shouldDecompressImages")]
        bool ShouldDecompressImages { get; set; }

        // @required -(NSURLCredential * _Nullable)credential;
        [Export("credential")]
        [return: NullAllowed]
        NSUrlCredential Credential();

        // @required -(void)setCredential:(NSURLCredential * _Nullable)value;
        [Export("setCredential:")]
        void SetCredential([NullAllowed] NSUrlCredential value);
    }

    // @interface SDWebImageDownloaderOperation : NSOperation <SDWebImageDownloaderOperationInterface, SDWebImageOperation, NSURLSessionTaskDelegate, NSURLSessionDataDelegate>
    [BaseType(typeof(NSOperation))]
    interface SDWebImageDownloaderOperation : SDWebImageDownloaderOperationInterface, ISDWebImageOperation, INSUrlSessionTaskDelegate, INSUrlSessionDataDelegate
    {
        // @property (readonly, nonatomic, strong) NSURLRequest * _Nullable request;
        [NullAllowed, Export("request", ArgumentSemantic.Strong)]
        NSUrlRequest Request { get; }

        // @property (readonly, nonatomic, strong) NSURLSessionTask * _Nullable dataTask;
        [NullAllowed, Export("dataTask", ArgumentSemantic.Strong)]
        NSUrlSessionTask DataTask { get; }

        // @property (assign, nonatomic) BOOL shouldDecompressImages;
        [Export("shouldDecompressImages")]
        bool ShouldDecompressImages { get; set; }

        // @property (assign, nonatomic) BOOL shouldUseCredentialStorage __attribute__((deprecated("Property deprecated. Does nothing. Kept only for backwards compatibility")));
        [Export("shouldUseCredentialStorage")]
        bool ShouldUseCredentialStorage { get; set; }

        //// @property (nonatomic, strong) NSURLCredential * _Nullable credential;
        //[NullAllowed, Export("credential", ArgumentSemantic.Strong)]
        //NSUrlCredential Credential { get; set; }

        // @property (readonly, assign, nonatomic) SDWebImageDownloaderOptions options;
        [Export("options", ArgumentSemantic.Assign)]
        SDWebImageDownloaderOptions Options { get; }

        // @property (assign, nonatomic) NSInteger expectedSize;
        [Export("expectedSize")]
        nint ExpectedSize { get; set; }

        // @property (nonatomic, strong) NSURLResponse * _Nullable response;
        [NullAllowed, Export("response", ArgumentSemantic.Strong)]
        NSUrlResponse Response { get; set; }

        // -(instancetype _Nonnull)initWithRequest:(NSURLRequest * _Nullable)request inSession:(NSURLSession * _Nullable)session options:(SDWebImageDownloaderOptions)options __attribute__((objc_designated_initializer));
        [Export("initWithRequest:inSession:options:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] NSUrlRequest request, [NullAllowed] NSUrlSession session, SDWebImageDownloaderOptions options);

        // -(id _Nullable)addHandlersForProgress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDWebImageDownloaderCompletedBlock _Nullable)completedBlock;
        [Export("addHandlersForProgress:completed:")]
        [return: NullAllowed]
        NSObject AddHandlersForProgress([NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDWebImageDownloaderCompletedBlock completedBlock);

        // -(BOOL)cancel:(id _Nullable)token;
        [Export("cancel:")]
        bool Cancel([NullAllowed] NSObject token);
    }

    // @protocol SDWebImagePrefetcherDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImagePrefetcherDelegate
    {
        // @optional -(void)imagePrefetcher:(SDWebImagePrefetcher * _Nonnull)imagePrefetcher didPrefetchURL:(NSURL * _Nullable)imageURL finishedCount:(NSUInteger)finishedCount totalCount:(NSUInteger)totalCount;
        [Export("imagePrefetcher:didPrefetchURL:finishedCount:totalCount:")]
        void DidPrefetchURL(SDWebImagePrefetcher imagePrefetcher, [NullAllowed] NSUrl imageURL, nuint finishedCount, nuint totalCount);

        // @optional -(void)imagePrefetcher:(SDWebImagePrefetcher * _Nonnull)imagePrefetcher didFinishWithTotalCount:(NSUInteger)totalCount skippedCount:(NSUInteger)skippedCount;
        [Export("imagePrefetcher:didFinishWithTotalCount:skippedCount:")]
        void DidFinishWithTotalCount(SDWebImagePrefetcher imagePrefetcher, nuint totalCount, nuint skippedCount);
    }

    // typedef void (^SDWebImagePrefetcherProgressBlock)(NSUInteger, NSUInteger);
    delegate void SDWebImagePrefetcherProgressBlock(nuint arg0, nuint arg1);

    // typedef void (^SDWebImagePrefetcherCompletionBlock)(NSUInteger, NSUInteger);
    delegate void SDWebImagePrefetcherCompletionBlock(nuint arg0, nuint arg1);

    // @interface SDWebImagePrefetcher : NSObject
    [BaseType(typeof(NSObject))]
    interface SDWebImagePrefetcher
    {
        // @property (readonly, nonatomic, strong) SDWebImageManager * _Nonnull manager;
        [Export("manager", ArgumentSemantic.Strong)]
        SDWebImageManager Manager { get; }

        // @property (assign, nonatomic) NSUInteger maxConcurrentDownloads;
        [Export("maxConcurrentDownloads")]
        nuint MaxConcurrentDownloads { get; set; }

        // @property (assign, nonatomic) SDWebImageOptions options;
        [Export("options", ArgumentSemantic.Assign)]
        SDWebImageOptions Options { get; set; }

        // @property (assign, nonatomic) dispatch_queue_t _Nonnull prefetcherQueue;
        [Export("prefetcherQueue", ArgumentSemantic.Assign)]
        DispatchQueue PrefetcherQueue { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SDWebImagePrefetcherDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SDWebImagePrefetcherDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype _Nonnull)sharedImagePrefetcher;
        [Static]
        [Export("sharedImagePrefetcher")]
        SDWebImagePrefetcher SharedImagePrefetcher();

        // -(instancetype _Nonnull)initWithImageManager:(SDWebImageManager * _Nonnull)manager __attribute__((objc_designated_initializer));
        [Export("initWithImageManager:")]
        [DesignatedInitializer]
        IntPtr Constructor(SDWebImageManager manager);

        // -(void)prefetchURLs:(NSArray<NSURL *> * _Nullable)urls;
        [Export("prefetchURLs:")]
        void PrefetchURLs([NullAllowed] NSUrl[] urls);

        // -(void)prefetchURLs:(NSArray<NSURL *> * _Nullable)urls progress:(SDWebImagePrefetcherProgressBlock _Nullable)progressBlock completed:(SDWebImagePrefetcherCompletionBlock _Nullable)completionBlock;
        [Export("prefetchURLs:progress:completed:")]
        void PrefetchURLs([NullAllowed] NSUrl[] urls, [NullAllowed] SDWebImagePrefetcherProgressBlock progressBlock, [NullAllowed] SDWebImagePrefetcherCompletionBlock completionBlock);

        // -(void)cancelPrefetching;
        [Export("cancelPrefetching")]
        void CancelPrefetching();
    }

    // @interface WebCache (UIButton)
    [Category]
    [BaseType(typeof(UIButton))]
    interface UIButton_WebCache
    {
        // -(NSURL * _Nullable)sd_currentImageURL;
        [NullAllowed, Export("sd_currentImageURL")]
        NSUrl GetImage();

        // -(NSURL * _Nullable)sd_imageURLForState:(UIControlState)state;
        [Export("sd_imageURLForState:")]
        [return: NullAllowed]
        NSUrl GetImage(UIControlState state);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state;
        [Export("sd_setImageWithURL:forState:")]
        void SetImage([NullAllowed] NSUrl url, UIControlState state);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setImageWithURL:forState:placeholderImage:")]
        void SetImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setImageWithURL:forState:placeholderImage:options:")]
        void SetImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:forState:completed:")]
        void SetImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:forState:placeholderImage:completed:")]
        void SetImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:forState:placeholderImage:options:completed:")]
        void SetImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state;
        [Export("sd_setBackgroundImageWithURL:forState:")]
        void SetBackgroundImage([NullAllowed] NSUrl url, UIControlState state);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:")]
        void SetBackgroundImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:options:")]
        void SetBackgroundImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setBackgroundImageWithURL:forState:completed:")]
        void SetBackgroundImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:completed:")]
        void SetBackgroundImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:options:completed:")]
        void SetBackgroundImage([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_cancelImageLoadForState:(UIControlState)state;
        [Export("sd_cancelImageLoadForState:")]
        void CancelImageLoadForState(UIControlState state);

        // -(void)sd_cancelBackgroundImageLoadForState:(UIControlState)state;
        [Export("sd_cancelBackgroundImageLoadForState:")]
        void CancelBackgroundImageLoadForState(UIControlState state);
    }

    // @interface GIF (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_GIF
    {
        // +(UIImage *)sd_animatedGIFWithData:(NSData *)data;
        [Static]
        [Export("sd_animatedGIFWithData:")]
        UIImage AnimatedGIFWithData(NSData data);

        // -(BOOL)isGIF;
        [Static]
        [Export("isGIF")]
        bool IsGIF();
    }

    // @interface MultiFormat (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_MultiFormat
    {
        // +(UIImage * _Nullable)sd_imageWithData:(NSData * _Nullable)data;
        [Static]
        [Export("sd_imageWithData:")]
        [return: NullAllowed]
        UIImage ImageWithData([NullAllowed] NSData data);

        // -(NSData * _Nullable)sd_imageData;
        [Static]
        [NullAllowed, Export("sd_imageData")]
        NSData ImageData();

        // -(NSData * _Nullable)sd_imageDataAsFormat:(SDImageFormat)imageFormat;
        [Export("sd_imageDataAsFormat:")]
        [return: NullAllowed]
        NSData ImageDataAsFormat(SDImageFormat imageFormat);
    }

    // @interface HighlightedWebCache (UIImageView)
    [Category]
    [BaseType(typeof(UIImageView))]
    interface UIImageView_HighlightedWebCache
    {
        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url;
        [Export("sd_setHighlightedImageWithURL:")]
        void SetHighlightedImage([NullAllowed] NSUrl url);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options;
        [Export("sd_setHighlightedImageWithURL:options:")]
        void SetHighlightedImage([NullAllowed] NSUrl url, SDWebImageOptions options);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setHighlightedImageWithURL:completed:")]
        void SetHighlightedImage([NullAllowed] NSUrl url, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setHighlightedImageWithURL:options:completed:")]
        void SetHighlightedImage([NullAllowed] NSUrl url, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setHighlightedImageWithURL:options:progress:completed:")]
        void SetHighlightedImage([NullAllowed] NSUrl url, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);
    }

    // @interface WebCache (UIImageView)
    [Category]
    [BaseType(typeof(UIImageView))]
    interface UIImageView_WebCache
    {
        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url;
        [Export("sd_setImageWithURL:")]
        void SetImage([NullAllowed] NSUrl url);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setImageWithURL:placeholderImage:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setImageWithURL:placeholderImage:options:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:options:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:options:progress:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithPreviousCachedImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithPreviousCachedImageWithURL:placeholderImage:options:progress:completed:")]
        void SetImageWithPreviousCachedImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setAnimationImagesWithURLs:(NSArray<NSURL *> * _Nonnull)arrayOfURLs;
        [Export("sd_setAnimationImagesWithURLs:")]
        void SetAnimationImages(NSUrl[] arrayOfURLs);

        // -(void)sd_cancelCurrentAnimationImagesLoad;
        [Export("sd_cancelCurrentAnimationImagesLoad")]
        void CancelCurrentAnimationImagesLoad();
    }

    // typedef void (^SDSetImageBlock)(UIImage * _Nullable, NSData * _Nullable);
    delegate void SDSetImageBlock([NullAllowed] UIImage image, [NullAllowed] NSData data);

    // @interface WebCache (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_WebCache
    {
        // -(NSURL * _Nullable)sd_imageURL;
        [NullAllowed, Export("sd_imageURL")]
        NSUrl GetImage();

        // -(void)sd_internalSetImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options operationKey:(NSString * _Nullable)operationKey setImageBlock:(SDSetImageBlock _Nullable)setImageBlock progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_internalSetImageWithURL:placeholderImage:options:operationKey:setImageBlock:progress:completed:")]
        void SetImage([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] string operationKey, [NullAllowed] SDSetImageBlock setImageBlock, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_cancelCurrentImageLoad;
        [Export("sd_cancelCurrentImageLoad")]
        void CancelCurrentImageLoad();

        // -(void)sd_setShowActivityIndicatorView:(BOOL)show;
        [Export("sd_setShowActivityIndicatorView:")]
        void ShowActivityIndicatorView(bool show);

        // -(void)sd_setIndicatorStyle:(UIActivityIndicatorViewStyle)style;
        [Export("sd_setIndicatorStyle:")]
        void SetIndicatorStyle(UIActivityIndicatorViewStyle style);

        // -(BOOL)sd_showActivityIndicatorView;
        [Export("sd_showActivityIndicatorView")]
        bool IsShowActivityIndicatorView();

        // -(void)sd_addActivityIndicator;
        [Export("sd_addActivityIndicator")]
        void AddActivityIndicator();

        // -(void)sd_removeActivityIndicator;
        [Export("sd_removeActivityIndicator")]
        void RemoveActivityIndicator();
    }

    // @interface WebCacheOperation (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_WebCacheOperation
    {
        // -(void)sd_setImageLoadOperation:(id _Nullable)operation forKey:(NSString * _Nullable)key;
        [Export("sd_setImageLoadOperation:forKey:")]
        void SetImageLoadOperation([NullAllowed] NSObject operation, [NullAllowed] string key);

        // -(void)sd_cancelImageLoadOperationWithKey:(NSString * _Nullable)key;
        [Export("sd_cancelImageLoadOperationWithKey:")]
        void CancelImageLoadOperationWithKey([NullAllowed] string key);

        // -(void)sd_removeImageLoadOperationWithKey:(NSString * _Nullable)key;
        [Export("sd_removeImageLoadOperationWithKey:")]
        void RemoveImageLoadOperationWithKey([NullAllowed] string key);
    }
}