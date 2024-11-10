import useSWR, { SWRResponse, mutate } from 'swr';
import type { StateCreator } from 'zustand/vanilla';
import type { UserStore } from '@/store/user';
import { preferenceSelectors } from '../preference/selectors';

const GET_USER_STATE_KEY = 'initUserState';
/**
 * 设置操作
 */
export interface CommonAction {
    refreshUserState: () => Promise<void>;

    updateAvatar: (avatar: string) => Promise<void>;
    useCheckTrace: (shouldFetch: boolean) => SWRResponse;
}

export const createCommonSlice: StateCreator<
    UserStore,
    [['zustand/devtools', never]],
    [],
    CommonAction
> = (set, get) => ({
    refreshUserState: async () => {
        await mutate(GET_USER_STATE_KEY);
    },
    updateAvatar: async (avatar) => {
        // const clientService = new ClientService();

        // await clientService.updateAvatar(avatar);
        await get().refreshUserState();
    },

    useCheckTrace: (shouldFetch) =>
        useSWR<boolean>(
            shouldFetch ? 'checkTrace' : null,
            () => {
                const userAllowTrace = preferenceSelectors.userAllowTrace(get());

                // if user have set the trace, return false
                if (typeof userAllowTrace === 'boolean') return Promise.resolve(false);

                return Promise.resolve(get().isUserCanEnableTrace);
            },
            {
                revalidateOnFocus: false,
            },
        ),

});
