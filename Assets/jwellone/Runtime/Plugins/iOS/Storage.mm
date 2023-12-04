extern "C"
{
    int64_t getAvailableDiskSpace()
    {
        NSURL *fileURL = [[NSURL alloc] initFileURLWithPath: NSHomeDirectory()];
        NSError *error = nil;
        NSDictionary *dict = [fileURL resourceValuesForKeys: @[NSURLVolumeAvailableCapacityForImportantUsageKey] error: &error];
        
        if (dict)
        {
            return (int64_t)[[dict objectForKey: NSURLVolumeAvailableCapacityForImportantUsageKey] longLongValue];
        }

#ifndef NDEBUG
        NSLog(@"Error Obtaining Volume Available Capacity: Domain = %@, Code = %ld", [error domain], (long)[error code]);
#endif

        return 0;
    }

    int64_t getTotalDiskSpace()
    {
        NSURL *fileURL = [[NSURL alloc] initFileURLWithPath: NSHomeDirectory()];
        NSError *error = nil;
        NSDictionary *dict = [fileURL resourceValuesForKeys: @[NSURLVolumeTotalCapacityKey] error: &error];
        
        if (dict) 
        {
            return (int64_t)[[dict objectForKey: NSURLVolumeTotalCapacityKey] longLongValue];
        }
        
#ifndef NDEBUG
        NSLog(@"Error Obtaining Volume Total Capacity: Domain = %@, Code = %ld", [error domain], (long)[error code]);
#endif
        
        return 0;
    }

    int64_t getUsedDiskSpace()
    {
        return getTotalDiskSpace() - getAvailableDiskSpace();
    }
}
