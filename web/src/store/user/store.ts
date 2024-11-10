import { subscribeWithSelector } from 'zustand/middleware';
import { shallow } from 'zustand/shallow';
import { createWithEqualityFn } from 'zustand/traditional';
import { StateCreator } from 'zustand/vanilla';

import { createDevtools } from '../middleware/createDevtools';
import { type UserState, initialState } from './initialState';
import { type UserAuthAction, createAuthSlice } from './slices/auth/action';
import { type CommonAction, createCommonSlice } from './slices/common/action';
import { type PreferenceAction, createPreferenceSlice } from './slices/preference/action';

//  ===============  聚合 createStoreFn ============ //

export type UserStore =
    UserState &
    PreferenceAction &
    UserAuthAction &
    CommonAction;

const createStore: StateCreator<UserStore, [['zustand/devtools', never]]> = (...parameters) => ({
    ...initialState,
    ...createPreferenceSlice(...parameters),
    ...createAuthSlice(...parameters),
    ...createCommonSlice(...parameters),
});

//  ===============  实装 useStore ============ //

const devtools = createDevtools('user');

export const useUserStore = createWithEqualityFn<UserStore>()(
    subscribeWithSelector(devtools(createStore)),
    shallow,
);
