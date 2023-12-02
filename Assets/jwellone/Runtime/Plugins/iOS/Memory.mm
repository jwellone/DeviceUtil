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
}
