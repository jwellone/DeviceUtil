package com.jwellone.memory;

import com.unity3d.player.UnityPlayer;
import android.app.ActivityManager;
import android.content.Context;

import java.io.BufferedReader;
import java.io.FileReader;

public class Memory {
    private static final int PAGE_SIZE = 4 * 1024;
    public static long getUsedMemorySize() {
        try (final FileReader fileReader = new FileReader("/proc/self/statm");
             final BufferedReader reader = new BufferedReader(fileReader)) {

            String statm = reader.readLine();
            if (statm == null) {
                return 0;
            }

            final String[] stats = statm.split("[ \t]", 3);
            if (stats.length < 2) {
                return 0;
            }

            return Long.parseLong(stats[1]) * PAGE_SIZE;
        } catch (Exception e) {
        }

        return 0;
    }

    public static long getAvailableMemorySize() {
        return getMemoryInfo().availMem;
    }

    public static long getTotalMemorySize() {
        return getMemoryInfo().totalMem;
    }

    private static ActivityManager.MemoryInfo getMemoryInfo()
    {
        final Context context = UnityPlayer.currentActivity.getApplication().getApplicationContext();
        final ActivityManager activityManager = (ActivityManager) context.getSystemService(Context.ACTIVITY_SERVICE);
        final ActivityManager.MemoryInfo info = new ActivityManager.MemoryInfo();
        activityManager.getMemoryInfo(info);
        return info;
    }
}
