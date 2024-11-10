import isEqual from 'fast-deep-equal';
import { produce } from 'immer';
import useSWR, { SWRResponse } from 'swr';
import type { StateCreator } from 'zustand/vanilla';

import { INBOX_SESSION_ID } from '@/const/session';
import { SESSION_CHAT_URL } from '@/const/url';
import { useOnlyFetchOnceSWR } from '@/libs/swr';
import type { GlobalStore } from '@/store/global/index';
import { merge } from '@/utils/merge';

import type { SystemStatus } from './initialState';

/**
 * 设置操作
 */
export interface GlobalStoreAction {
    switchBackToChat: (sessionId?: number) => void;
    toggleChatSideBar: (visible?: boolean) => void;
    toggleExpandSessionGroup: (id: string, expand: boolean) => void;
    toggleMobilePortal: (visible?: boolean) => void;
    toggleMobileTopic: (visible?: boolean) => void;
    toggleSystemRole: (visible?: boolean) => void;
    toggleZenMode: () => void;
    updateSystemStatus: (status: Partial<SystemStatus>, action?: any) => void;
    useCheckLatestVersion: (enabledCheck?: boolean) => SWRResponse<string>;
    useInitSystemStatus: () => SWRResponse;
    currentTheme: (theme: 'auto' | 'light' | 'dark') => void;
}

export const globalActionSlice: StateCreator<
    GlobalStore,
    [['zustand/devtools', never]],
    [],
    GlobalStoreAction
> = (set, get) => ({
    switchBackToChat: (sessionId) => {
        get().router?.push(SESSION_CHAT_URL(sessionId || INBOX_SESSION_ID, get().isMobile));
    },
    toggleChatSideBar: (newValue) => {
        const showChatSideBar =
            typeof newValue === 'boolean' ? newValue : !get().status.showChatSideBar;

        get().updateSystemStatus({ showChatSideBar });
    },
    toggleExpandSessionGroup: (id, expand) => {
        const { status } = get();
        const nextExpandSessionGroup = produce(status.expandSessionGroupKeys, (draft: string[]) => {
            if (expand) {
                if (draft.includes(id)) return;
                draft.push(id);
            } else {
                const index = draft.indexOf(id);
                if (index !== -1) draft.splice(index, 1);
            }
        });
        get().updateSystemStatus({ expandSessionGroupKeys: nextExpandSessionGroup });
    },
    toggleMobilePortal: (newValue) => {
        const mobileShowPortal =
            typeof newValue === 'boolean' ? newValue : !get().status.mobileShowPortal;

        get().updateSystemStatus({ mobileShowPortal });
    },
    toggleMobileTopic: (newValue) => {
        const mobileShowTopic =
            typeof newValue === 'boolean' ? newValue : !get().status.mobileShowTopic;

        get().updateSystemStatus({ mobileShowTopic }, newValue);
    },
    toggleSystemRole: (newValue) => {
        const showSystemRole = typeof newValue === 'boolean' ? newValue : !get().status.mobileShowTopic;

        get().updateSystemStatus({ showSystemRole }, newValue);
    },
    toggleZenMode: () => {
        const { status } = get();
        const nextZenMode = !status.zenMode;

        get().updateSystemStatus({ zenMode: nextZenMode });
    },
    updateSystemStatus: (status, action) => {
        const nextStatus = merge(get().status, status);
        if (isEqual(get().status, nextStatus)) return;

        set({ status: nextStatus }, false, action);

        get().statusStorage?.saveToLocalStorage(nextStatus);
    },

    useCheckLatestVersion: (enabledCheck = true) =>
        useSWR(enabledCheck ? 'checkLatestVersion' : null, {
            // check latest version every 30 minutes
            focusThrottleInterval: 1000 * 60 * 30,
            onSuccess: (data: string) => {
                // if (!valid(CURRENT_VERSION) || !valid(data)) return;

                // // Parse versions to ensure we're working with valid SemVer objects
                // const currentVersion = parse(CURRENT_VERSION);
                // const latestVersion = parse(data);

                // if (!currentVersion || !latestVersion) return;

                // // only compare major and minor versions
                // // solve the problem of frequent patch updates
                // const currentMajorMinor = `${currentVersion.major}.${currentVersion.minor}.0`;
                // const latestMajorMinor = `${latestVersion.major}.${latestVersion.minor}.0`;

                // if (gt(latestMajorMinor, currentMajorMinor)) {
                //   set({ hasNewVersion: true, latestVersion: data }, false, n('checkLatestVersion'));
                // }

            },
        }),

    useInitSystemStatus: () =>
        useOnlyFetchOnceSWR<SystemStatus>(
            'initSystemStatus',
            () => get().statusStorage.getFromLocalStorage(),
            {
                onSuccess: (status) => {
                    set({ isStatusInit: true }, false, 'setStatusInit');

                    get().updateSystemStatus(status, 'initSystemStatus');
                },
            },
        ),
    currentTheme: (theme) => {
        localStorage.setItem('theme', theme);
        set({
            theme: theme
        });
    }
});
