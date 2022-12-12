# SDWebImage .Net7

    xcodebuild archive 
    -project sdwebimage.xcodeproj
    -scheme SomeFramework 
    -destination "generic/platform=iOS"
    -archivePath "archives/sdwebimage"
    SKIP_INSTALL=NO
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES

    xcodebuild -create-xcframework -library libsdwebimage.a -output libsdwebimage.xcframework
