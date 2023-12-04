#import <mach/mach.h>

extern "C"
{
    int64_t getUsedMemorySize()
    {
        task_vm_info_data_t info;
        mach_msg_type_number_t size = TASK_VM_INFO_COUNT;
        kern_return_t status = task_info(mach_task_self(), TASK_VM_INFO, (task_info_t)&info, &size);

        if (status != KERN_SUCCESS)
        {
#ifndef NDEBUG
            NSLog(@"%s(): Error in task_info(): %s", __FUNCTION__, strerror(errno));
#endif
            return 0;
        }
        
        return (int64_t)info.phys_footprint;
    }

    int64_t getAvailableMemorySize()
    {
        if (@available(iOS 13.0, *)) 
        {
            return (int64_t)os_proc_available_memory();
        }
        
#ifndef NDEBUG
        NSLog(@"'os_proc_available_memory' is only available on iOS 13.0 or newer");
#endif
        return 0;
    }

    int64_t getTotalMemorySize()
    {
        return [[NSProcessInfo processInfo] physicalMemory];
    }
}
