import { StateCreator } from 'zustand/vanilla';

import { enableAuth } from '@/const/auth';

import { UserStore } from '../../store';

export interface UserAuthAction {
    enableAuth: () => boolean;
    /**
     * universal logout method
     */
    logout: () => Promise<void>;
    /**
     * universal login method
     */
    openLogin: () => Promise<void>;
    openUserProfile: () => Promise<void>;
}

export const createAuthSlice: StateCreator<
    UserStore,
    [['zustand/devtools', never]],
    [],
    UserAuthAction
> = (set, get) => ({
    enableAuth: () => {
        return enableAuth ?? false;
    },
    logout: async () => {
        if (enableAuth) {
            // get().clerkSignOut?.({ redirectUrl: location.toString() });

            return;
        }

        const enableNextAuth = get().enabledNextAuth;
        if (enableNextAuth) {

        }
    },
    openLogin: async () => {
        if (enableAuth) {
            const reditectUrl = location.toString();
            // get().clerkSignIn?.({
            //     fallbackRedirectUrl: reditectUrl,
            //     signUpForceRedirectUrl: reditectUrl,
            //     signUpUrl: '/signup',
            // });

            return;
        }

        const enableNextAuth = get().enabledNextAuth;
        if (enableNextAuth) {
            // Check if only one provider is available
            const providers = get()?.oAuthSSOProviders;
            if (providers && providers.length === 1) {

                return;
            }

        }
    },

    openUserProfile: async () => {
        if (enableAuth) {
            // get().clerkOpenUserProfile?.();

            return;
        }
    },
});
