import type { StateCreator } from 'zustand/vanilla';

import type { UserStore } from '@/store/user';
import { UserGuide, UserPreference } from '@/types/user';
import { merge } from '@/utils/merge';

export interface PreferenceAction {
    updateGuideState: (guide: Partial<UserGuide>) => Promise<void>;
    updatePreference: (preference: Partial<UserPreference>, action?: any) => Promise<void>;
    openUserProfile: () => Promise<void>;
}

export const createPreferenceSlice: StateCreator<
    UserStore,
    [['zustand/devtools', never]],
    [],
    PreferenceAction
> = (set, get) => ({
    updateGuideState: async (guide) => {
        const { updatePreference } = get();
        const nextGuide = merge(get().preference.guide, guide);
        await updatePreference({ guide: nextGuide });
    },

    updatePreference: async (preference, action) => {
        const nextPreference = merge(get().preference, preference);

        set({ preference: nextPreference }, false, action);

        // await userService.updatePreference(nextPreference);
    },
    openUserProfile: async () => {

    }
});
