# SDWebImage

xcodebuild archive 
    -project sdwebimage.xcodeproj
    -scheme SomeFramework 
    -destination "generic/platform=iOS"
    -archivePath "archives/sdwebimage"
    SKIP_INSTALL=NO
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES

    xcodebuild -create-xcframework -library libsdwebimage.a -headers /GitHub/SDWebImage/Obj-C/build/sdwebimage.build/Release-iphoneos/sdwebimage.build/all-product-headers.yaml -output libsdwebimage.xcframework
